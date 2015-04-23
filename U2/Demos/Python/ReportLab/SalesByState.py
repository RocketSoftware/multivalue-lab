#!/usr/bin/env python
import u2py
from reportlab.graphics.shapes import Drawing
from reportlab.graphics.charts.barcharts import VerticalBarChart
from reportlab.platypus import *
from reportlab.lib.styles import getSampleStyleSheet
from reportlab.rl_config import defaultPageSize
from reportlab.lib.units import inch
import xml.etree.ElementTree as ET

PAGE_HEIGHT=defaultPageSize[1]
styles = getSampleStyleSheet()
Title = "Sales by State"
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
  
def graphout(statenames, data):
    drawing = Drawing(500, 200)
    lc = VerticalBarChart()
    lc.x = 30
    lc.y = 50
    lc.height = 125
    lc.width = 450
    lc.data = data
    statenames = statenames
    lc.categoryAxis.categoryNames = statenames
    lc.categoryAxis.labels.boxAnchor = 'n'
    lc.categoryAxis.labels.angle = 270
    lc.valueAxis.valueMin = 0
    lc.valueAxis.valueMax = 10000000 #1500
    lc.valueAxis.valueStep = 1000000 #300
    drawing.add(lc)
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
  
yearly_title = header("Sales from PLOCATION by STATE")
yearly_explain = p("""This shows Sales By State""")

statenames = []
data = []
values = []

#simulate an EXECUTE
cmd = u2py.Command('COMO ON XML')
cmd.run()
cmd = u2py.Command('SQL SELECT STATE,SUM(SALES) FROM PLOCATION GROUP BY STATE TOXML ELEMENTS;')
cmd.run()
cmd = u2py.Command('COMO OFF')
cmd.run()
file = u2py.File('_PH_')
xml = str(file.read('O_XML'))
p1 = xml.find('<ROOT>')
xml = xml[p1:]
p1 = xml.find('</ROOT>')
xml = xml[0: p1 + 7]
#print("xml->" + xml)
STATE = ''
tree = ET.fromstring(xml)
for child in tree:
    #print(child.tag + "->" + child.text)
    if child.tag == "PLOCATION":
        for plocation in child:
            if plocation.tag == "STATE":
                STATE = plocation.text
            else:
                if plocation.tag == "SUM_Sales_":
                    value = float(plocation.text)
                    statenames.append(STATE)
                    values.append(value)
                    print(STATE + "->" + str(value))

data.append(values)
yearly_chart = graphout(statenames, data)
yearly_section = [yearly_title, yearly_explain, yearly_chart]
Elements.extend(yearly_section)
 
doc = SimpleDocTemplate('PLOCATION-BY-STATE.pdf')
doc.build(Elements)
