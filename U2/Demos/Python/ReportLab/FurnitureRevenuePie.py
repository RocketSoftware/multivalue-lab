#!/usr/bin/env python
import u2py
from reportlab.graphics.shapes import Drawing
from reportlab.platypus import *
from reportlab.lib.styles import getSampleStyleSheet
from reportlab.rl_config import defaultPageSize
from reportlab.lib.units import inch
import xml.etree.ElementTree as ET

from reportlab.graphics.charts.piecharts import Pie

PAGE_HEIGHT=defaultPageSize[1]
styles = getSampleStyleSheet()
Title = "Sales by prod_cat"
Author = "David Rose"
URL = "http://www.mbs.net.au"
email = "david.rose@mbs.net.au"
Abstract = """This is a simple example document that illustrates how to extract U2 data to create a basic PDF with a chart.
I used the PLATYPUS library, which is part of ReportLab, and the charting capabilities built into ReportLab."""
Elements=[]
HeaderStyle = styles["Heading1"]
ParaStyle = styles["Normal"]
PreStyle = styles["Code"]
 
def header(txt, style=HeaderStyle, klass=Paragraph, sep=0.3):
    s = Spacer(0.2*inch, sep*inch)
    para = klass(txt, style)
    sect = [s, para]
    result = KeepTogether(sect)
    return result
 
def p(txt):
    return header(txt, style=ParaStyle, sep=0.1)
 
def pre(txt):
    s = Spacer(0.1*inch, 0.1*inch)
    p = Preformatted(txt, PreStyle)
    precomps = [s,p]
    result = KeepTogether(precomps)
    return result
  
def graphout(prod_catnames, data):
    drawing = Drawing(500, 200)
    pie = Pie()

    pie.sideLabels       = 1
    pie.labels           = prod_catnames
    pie.data             =  data[0]
    pie.width            = 140
    pie.height           = 140
    pie.y                = 35
    pie.x                = 125
    pie.slices.popout = 5 
    
    drawing.add(pie)
        
    return drawing

#
## execution starts here
#
mytitle = header(Title)
myname = header(Author, sep=0.1, style=ParaStyle)
mysite = header(URL, sep=0.1, style=ParaStyle)
mymail = header(email, sep=0.1, style=ParaStyle)
abstract_title = header("ABSTRACT")
myabstract = p(Abstract)
head_info = [mytitle, myname, mysite, mymail, abstract_title, myabstract]
Elements.extend(head_info)
  
yearly_title = header("Revenue from FUR_REV by Product Category")
yearly_explain = p("This shows Revenue By Product Category")

prod_catnames = []
data = []
values = []

cmd = u2py.Command('SQL SELECT PROD_CAT,SUM(REVENUE) FROM FUR_REV GROUP BY PROD_CAT TOXML ELEMENTS TO "FUR_REV";')
cmd.run()
file = u2py.File('_XML_')
xml = str(file.read('FUR_REV.xml'))
p1 = xml.find('<ROOT>')
xml = xml[p1:]
print("xml->" + xml)
prod_cat = ''
tree = ET.fromstring(xml)
for child in tree:
    #print(child.tag + "->" + child.text)
    if child.tag == "FUR_REV":
        for plocation in child:
            if plocation.tag == "PROD_CAT":
                prod_cat = plocation.text
            else:
                if plocation.tag == "SUM_Revenue_":
                    value = float(plocation.text)
                    prod_catnames.append(prod_cat)
                    values.append(value)
                    print(prod_cat + "->" + str(value))

data.append(values)
yearly_chart = graphout(prod_catnames, data)
yearly_section = [yearly_title, yearly_explain, yearly_chart]
Elements.extend(yearly_section)
 
doc = SimpleDocTemplate('FurnitureRevenuePie.pdf')
doc.build(Elements)
