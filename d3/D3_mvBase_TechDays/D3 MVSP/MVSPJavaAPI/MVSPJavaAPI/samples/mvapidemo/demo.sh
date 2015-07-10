#!/bin/bash
export CLASSPATH=./:/usr/lib/pick/MVSP/Java/lib/mvapi.jar:/usr/lib/pick/MVSP/Java/lib/TableLayout.jar
javac -cp $CLASSPATH CustMaint.java
java -cp $CLASSPATH CustMaint

