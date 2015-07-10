
 var count = "1";
 
 //*******************************************************Create a new row in the HTML table that allows user Input**********************************
  function addRow()
  {
			var table = document.getElementById("Cust_Table"); // create a variable to hold the HTML table structure the create an INPUT cell for each column***********

            var rowCount = table.rows.length;					
            var row = table.insertRow(rowCount);
            var cell1 = row.insertCell(0);
            var element1 = document.createElement("input");
            element1.type = "text";
            element1.name="Account#";
			element1.style['width'] = "90px";
			element1.style['align'] = "Center";
            cell1.appendChild(element1);

            var cell2 = row.insertCell(1);
            var element2 = document.createElement("input");
            element2.type = "text";
            element2.name="Name";
			element2.style['width'] = "285px";
            cell2.appendChild(element2);
           

            var cell3 = row.insertCell(2);
            var element3 = document.createElement("input");
            element3.type = "text";
			element3.style['width'] = "270px";
            element3.name = "Address";
            cell3.appendChild(element3);
			
			var cell4 = row.insertCell(3);
            var element4 = document.createElement("input");
            element4.type = "text";
            element4.name="City";
			element4.style['width'] = "225px";
            cell4.appendChild(element4);
            

            var cell5 = row.insertCell(4);
            var element5= document.createElement("input");
            element5.type = "text";
            element5.name = "State";
			element5.style['width'] = "50px";
            cell5.appendChild(element5);
			
			var cell6 = row.insertCell(5);
            var element6 = document.createElement("input");
            element6.type = "text";
            element6.name="Zip";
			element6.style['width'] = "95px";
            cell6.appendChild(element6);

            var cell7 = row.insertCell(6);
            var element7 = document.createElement("input");
            element7.type = "text";
            element7.name = "Phone";
			element7.style['width'] = "110px";
            cell7.appendChild(element7);
			
			var cell8 = row.insertCell(7);
            var element8 = document.createElement("input");
            element8.type = "Button";
			element8.id = "DeleteCustItem"
            element8.name = "Delete";
			element8.value = "Delete";
			element8.style['width'] = "63px";
			element8.onclick = function(){ delRow(this.parentNode.parentNode.rowIndex) };
            cell8.appendChild(element8);
			
			var cell9 = row.insertCell(8);
            var element9 = document.createElement("input");
            element9.type = "Button";
			element9.id = "WriteCustItem"
            element9.name = "Update";
			element9.value = "Write Record";
			element9.style['width'] = "120px";
			element9.style['color'] = "red";
			element9.onclick = function(){ WriteCustItem(this.parentNode.parentNode.rowIndex) };
            cell9.appendChild(element9);
  }         
//**************************************************Write a new Record******************************************************
  function WriteCustItem(RowIDX)
  {
	  
	  CustTableRow = document.getElementById("Cust_Table").rows(RowIDX);
	  
	
		   var Account = CustTableRow.cells(0).children[0].value;
		   var Name = CustTableRow.cells(1).children[0].value;
		   var Addr= CustTableRow.cells(2).children[0].value;
		   var City = CustTableRow.cells(3).children[0].value;
		   var State= CustTableRow.cells(4).children[0].value;
		   var Zip = CustTableRow.cells(5).children[0].value;
		   var Phone = CustTableRow.cells(6).children[0].value;
		   
		   document.getElementById("Cust_Table").deleteRow(RowIDX); // delete the input row
	
	       var tblBody = document.getElementById("Cust_Table").tBodies[0]; // clone another row so that we do not have to set the properties for each cell
		   var newNode = tblBody.rows[1].cloneNode(true); //NOTE: this approach will ONLY work if there is already at least 1 row in the table results. This sample program does not handle
		   tblBody.appendChild(newNode);					// the case were there are no rows already returned in the table. You would have to build up the entire row structure as desired

	      rows = document.getElementById("Cust_Table").rows(RowIDX); // get new row structure
	   
	  // overwrite the cloned row's data with what the user input into the new row
	   rows.cells(0).innerHTML = "<a href='http://localhost:81/D3_PHP_Rest/invoicelist.php?accountNo=" + Account +"'>"+ Account + "</a></td>";  // overwrite the href link with the new "entered" custID point to your host instead.																																			// usually you would have the DB your D3 Write routine generate this
	   rows.cells(1).innerHTML = Name;
	   rows.cells(2).innerHTML = Addr;
	   rows.cells(3).innerHTML = City;
	   rows.cells(4).innerHTML = State;
	   rows.cells(5).innerHTML = Zip;
	   rows.cells(6).innerHTML = Phone;
	   
	   //****************************************use Ajax approach to pass data to PHP document so PHP can communicate with D3************************
       var ajxhrec;  
       if (window.XMLHttpRequest) { // Mozilla, Safari, ...  
         ajxhrec = new XMLHttpRequest();  
		 
        } else if (window.ActiveXObject) { // IE 8 and older  
         ajxhrec = new ActiveXObject("Microsoft.XMLHTTP");  
      }  
      
	  var data = "Action=WriteItem";
	  var data = data + "&CUSTID=" + Account;
	  var data = data + "&NAME=" + encodeURIComponent(Name);
	  var data = data + "&ADDR=" + encodeURIComponent(Addr);
	  var data = data + "&CITY=" + encodeURIComponent(City);
	  var data = data + "&STATE=" + State;
	  var data = data + "&ZIP=" + Zip;
	  var data = data + "&PHONE=" + Phone;
	  
      ajxhrec.open("POST", "CustAjax.php", true);   
      ajxhrec.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");     
	  ajxhrec.onreadystatechange = function() {
	    if(ajxhrec.readyState == 4 && ajxhrec.status == 200) {
		    var return_data = ajxhrec.responseText;
			//alert(return_data);
	    }
    }
	
      ajxhrec.send(data);  
	}
	
  
  //**************************************************DElETE Function*******************************************
  function delRow(RowIDX)
  {
	   
	var CustAcct = document.getElementById('Cust_Table').rows[RowIDX].cells[0].innerText; // get the CustID from the 1st column of the table for the row selected
	if (CustAcct != "") {
	
	//****************************************use Ajax approach to pass data to PHP document so PHP can communicate with D3************************
       var ajxhrec;  
       if (window.XMLHttpRequest) { // Mozilla, Safari, ...  
         ajxhrec = new XMLHttpRequest();  
		 
        } else if (window.ActiveXObject) { // IE 8 and older  
         ajxhrec = new ActiveXObject("Microsoft.XMLHTTP");  
        }  
      var data = "Action=Delete";
	  var data = data + "&CUSTID=" + CustAcct;
      ajxhrec.open("POST", "CustAjax.php", true);   
      ajxhrec.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");                    
      ajxhrec.send(data);  // ajax type request
	}
	document.getElementById("Cust_Table").deleteRow(RowIDX); // remove row from HTML table of Customers
    
  }

