# Refactoring practice
Repository where I practice refactoring. I find refactoring tasks, open source projects or own small projects developed some time ago and refactor them to follow SOLID

## Block breaker
This is an enhanced solution for one of the seminars delivered in Game Development module at Westminster International University in Tashkent. The project is a prototype of Atari Breakout game made with Unity game engine.
 
I heavily refactored the solution to follow SRP and decomposed all the classes into separate standalone ones. The interactions between classes are done using publisher-subscriber design patter. I used UnityEvents for this example due to the ability to assign subscribers in Unity Editor. This allowed making components fully independent. Additionally, I applied decorator and visitor design patterns to make score update loosely coupled with its implementation.

## Have a guess
This is an enhanced solution for one of the seminars delivered in Game Development module at Westminster International University in Tashkent. The project is a prototype of guessing number gameplay made with Unity game engine.
 
I heavily refactored the solution to follow SRP and decomposed all the classes into separate standalone ones. The interactions between classes are done using publisher-subscriber design patter. I used UnityEvents for this example due to the ability to assign subscribers in Unity Editor. This allowed making components fully independent.

## IMJunior
I found a video with a task to refactor given code: https://www.youtube.com/watch?v=1eY2IomNcz4  
Before refactoring: https://pastebin.com/RSc7Uvqx  
  
The app is a primitive emulator of RPG mechanics. User as a character has a number of points that can be spent on abilities. Following DRY and SOLID, I made the solution more dynamic - abilities can be easily added or removed without crash for the app.

## MathEquationEvaluator
This is solution for several practical tasks given as a part of the course "Information Systems Architect" by GeekBrains.ru 
  
The requirement was to create a Calculator Console app that will evaluate a math equation and produce it in Reverse Polish Notation and show calculation result.

Supported operations: +, -, *, /, (, ), unary +, unary - 

Example:

Input: (1 + 2) * 4 + 3

Output: 

1 2 + 4 * 3 +

15

Important note: all major algorythms and dat structures required to be implemented manually. Arrays can be used. Assumption made that build in functions like string.Split or string.Join had to be implemented manually.

My solution includes validation for not supported characters and correctness of the equation (i.e. brackets mismatch, etc.); handles cases when there are extra spaces before/after operations; supports equations like --1, +-1.

The first task was to implement the requirement following structural paradigm (use only functions). Task was quite challanging as I got used to OOP paradigm. Initial commit has completion of the task.

The next task was to refactor initial solution to OOP paradign. I heavily refactored solution to make it more structure and apply SOLID principles.

You can evaluate the progression on the tasks by respective commits.

## Space Shooter
This is an enhanced solution for one of the seminars delivered in Game Development module at Westminster International University in Tashkent. The project is a prototype of endless space shooter gameplay made with Unity game engine.
 
I heavily refactored the solution to follow SRP and decomposed all the classes into separate standalone ones. As a result, all behavioural logic is modular and can be added as components of the objects. Additionally, I prefer using build-in C# events over UnityEvent. Even though it is very convenient to subscribe event receivers via Editor, C# events have better performance according to the following benchmark https://www.jacksondunstan.com/articles/3335

## SuperDrive
I decided to re-develop the course work that I did during level 4 of BSc Business Information Systems (Westminster International University in Tashkent) for Fundamentals of Programming module. The task (or technical requirements) is available here: https://github.com/mikhailShpirko/refactoring-practice/blob/master/SuperDrive/WIUT_FunPro_CW1_Sem2_2012_2013.pdf
 
The goal was to apply the principles of DDD and CQRS to the solution as well as follow DRY and SOLID. I made the clear separation of domains, commands and queries as well as wrote a custom extension for bubble sorting over a generic array and generic implementation of OleDb commands and queries.

## TicTacToe
I decided to refactor one of the seminars delivered on Fundamentals of Programming module (level 4) of BSc Business Information Systems (Westminster International University in Tashkent). Initially, the seminar is targeted at practising loops; the solution is structured in a simple way without strict following SOLID so that students with minimum programming knowledge should be able to complete it.
 
The goal was to apply SOLID principles to the project. I started by refactoring the functions to follow SRP and applying a consistent code style. After that, I decomposed all responsibilities to separate classes and defined presentation layer and game logic layer. Finally, I made loosely coupled relationships between classes via events and separated Game Logic to separate project. All the progression can be reviewed by analyzing commit history.

## TruckTour
I found a practice task on Hacker Rank for Data Structures: https://www.hackerrank.com/challenges/truck-tour/problem
 
I implemented solution to fulfil the requrements and followed SOLID principles upon the development. I decided to go with LinkedList and created extension to make circular linked list. Additionally, I covered critical parts of the solutions with Unit Tests to verify that calculation is valid and produces result according to the given rquirements.
