rem
rem Run the Java Customer Maintenance demo program.
rem
rem Note: Enable the MVSP.DEMO account in MVSP account MVSP.MENU prior to running this test.
rem
set CLASSPATH=classes;lib\mvapi.jar;lib\TableLayout.jar;src
"%JAVA_HOME%\bin\javac" -cp %CLASSPATH% -d classes src/CustMaint.java
copy product_icon.gif classes
rem
"%JAVA_HOME%\bin\java" -cp "%CLASSPATH%" CustMaint