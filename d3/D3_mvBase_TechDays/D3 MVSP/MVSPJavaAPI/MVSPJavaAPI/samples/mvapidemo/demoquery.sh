#!/bin/bash
export CLASSPATH=./:/usr/lib/pick/MVSP/Java/lib/mvapi.jar:/usr/lib/pick/MVSP/Java/lib/TableLayout.jar
javac -cp $CLASSPATH Demo.java
java -cp $CLASSPATH Demo localhost 9000 dm 

