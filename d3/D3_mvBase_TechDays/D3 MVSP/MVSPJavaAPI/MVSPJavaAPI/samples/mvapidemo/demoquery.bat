rem
rem Run Java MVAPI demo program.
rem
rem Note: Enable the MVSP.DEMO account in MVSP account MVSP.MENU prior to running this test.
rem
javac -cp lib\mvapi.jar -d classes src/Demo.java
rem
rem specify the hostname portnumber and username on the command line:
rem
java -cp lib\mvapi.jar;classes Demo localhost 9000 dm