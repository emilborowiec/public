# Java command line tools

## Java compiler

Compile a single java source file

```
javac <file_name>
```

## Java runtime

Run a compiled class (this will try to find the class in current directory):

```
java <class_name>
```

Or give it classpath where it should search or classes

```
java -cp <path_to_class> <class_name>
```

Run jar archive

```
java -jar <jar_file>
```

## Jar

The jar command is used to create jar archives or manipulate them.

Create an archive, classes.jar, that contains two class files, Foo.class and Bar.class.

```
jar --create --file classes.jar Foo.class Bar.class
```

Create an archive, classes.jar, by using an existing manifest, mymanifest, 
that contains all of the files in the directory foo/.

```
jar --create --file classes.jar --manifest mymanifest -C foo/
```

Create a modular JAR archive,foo.jar, 
where the module descriptor is located in classes/module-info.class.

```
jar --create --file foo.jar --main-class com.foo.Main --module-version 1.0 -C foo/classes resources
```


Update an existing non-modular JAR, foo.jar, to a modular JAR file.

```
jar --update --file foo.jar --main-class com.foo.Main --module-version 1.0 -C foo/module-info.class
```


## JShell

Start jshell

```
jshell
```

Exit jshell

```
/exit
```