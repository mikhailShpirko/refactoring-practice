# Refactoring practice
Repository where I practice refactoring. I find refactoring tasks, open source projects or own small projects developed some time ago and refactor them to follow SOLID

## Have a guess
This is an enhanced solution for one of the seminars delivered in Game Development module at Westminster International University in Tashkent. The project is a prototype of guessing number gameplay made with Unity game engine.
 
I heavily refactored the solution to follow SRP and decomposed all the classes into separate standalone ones. The interactions between classes are done using publisher-subscriber design patter. I used UnityEvents for this example due to the ability to assign subscribers in Unity Editor. This allowed making components fully independent.

## IMJunior
I found a video with a task to refactor given code: https://www.youtube.com/watch?v=1eY2IomNcz4  
Before refactoring: https://pastebin.com/RSc7Uvqx  
  
The app is a primitive emulator of RPG mechanics. User as a character has a number of points that can be spent on abilities. Following DRY and SOLID, I made the solution more dynamic - abilities can be easily added or removed without crash for the app.

## Space Shooter
This is an enhanced solution for one of the seminars delivered in Game Development module at Westminster International University in Tashkent. The project is a prototype of endless space shooter gameplay made with Unity game engine.
 
I heavily refactored the solution to follow SRP and decomposed all the classes into separate standalone ones. As a result, all behavioural logic is modular and can be added as components of the objects. Additionally, I prefer using build-in C# events over UnityEvent. Even though it is very convenient to subscribe event receivers via Editor, C# events have better performance according to the following benchmark https://www.jacksondunstan.com/articles/3335

## SuperDrive
I decided to re-develop the course work that I did during level 4 of BSc Business Information Systems (Westminster International University in Tashkent) for Fundamentals of Programming module. The task (or technical requirements) is available here: https://github.com/mikhailShpirko/refactoring-practice/blob/master/SuperDrive/WIUT_FunPro_CW1_Sem2_2012_2013.pdf
 
The goal was to apply the principles of DDD and CQRS to the solution as well as follow DRY and SOLID. I made the clear separation of domains, commands and queries as well as wrote a custom extension for bubble sorting over a generic array and generic implementation of OleDb commands and queries.
