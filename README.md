
# GildedRose Refactoring Kata

Hi, my Name is Maximo Zoppini and this is my GildedRose refactoring Kata resolution.
This repository contains my solution to the **GildedRose** refactoring challenge. The primary objective of this exercise is to improve the quality of the legacy code while maintaining existing functionality and ensuring cleaner, more maintainable code. 

## Table of Contents

1. [Description](#description)
5. [Resolution](#resolution)
6. [Improvements Made](#improvements-made)
7. [Future Considerations](#future-considerations)
8. [Notes](#notes)

## Description

**GildedRose** is a small shop with magical items, managed by an inventory system that requires improvements. This exercise focuses on refactoring the existing code to make it more readable, maintainable, and scalable.

The challenge involves refactoring a class that manages different products, while keeping its original functionality intact.

## Build the project

Use your normal build tools to build the projects in Debug mode.
For example, you can use the `dotnet` command line tool:

``` cmd
dotnet build GildedRose.sln -c Debug
```

## Run the Gilded Rose Command-Line program

For e.g. 10 days:

``` cmd
GildedRose/bin/Debug/net8.0/GildedRose 10
```

## Run all the unit tests

``` cmd
dotnet test
```
## Run all the unit tests with VS

Just run all tests inside the GildedRoseTests project. 


## Resolution

To complete the challenge within the specified time of about 3 to 5 hours, I focused on the following steps:

1. **Analyzing the requirements README:** Before starting the refactoring, I took time to understand the project requirements and wrote tests to validate them. This was crucial to ensure that the changes made during the refactoring process continued to respect the original requirements.

2. **Simplifying conditionals:** I began by simplifying the conditionals in the original method, extracting repetitive values like item names and fixed values into constants. Once I understood the flow of the conditionals, I applied techniques such as "Consolidate Conditional Expression" and "Decompose Conditionals." After filtering similar executions, I inverted and simplified the if clauses, removing their else statements.

3. **Separation of responsibilities using polymorphism and interfaces:** In this step, I separated the logic for calculating `SellIn` and `Quality` of the items into a more readable and maintainable structure. I used a simple version of the Template Method pattern, specifying general functionality for all item types in a base class and then implementing variations of that functionality in the derived classes.

4. **Separation of item creation responsibility:** Finally, I moved the responsibility for creating items to a factory class using the Simple Factory pattern. This way, new item types could be dynamically added in the future without breaking the functionality of the `GildedRose` class.

The idea behind these steps was to apply techniques that adhere to SOLID principles such as "Single Responsibility," "Open/Closed Principle," "Liskov Substitution Principle," and "Dependency Inversion."

## Improvements Made

- **Code decoupling:** The logic for handling different items was split into separate classes to improve maintainability.
- **Conditional simplification:** Complex conditions were optimized to enhance code readability.
- **Unit testing:** Additional tests were added to cover edge cases and ensure code quality.

## Future Considerations

- **Adding more items:** The solution is prepared to handle new items with specific behaviors.
- **Adding strategy for common operations:** The common operations can be separated in a different structure to be reused and also they can be applied as Fluent Configurations
- **Allow more Configurations:** Allow the user to configure dynamically the items, adding them to the store and giving a posibility to configure its own item calculations. 

## Notes

C# NUnit original proyect has a verification file that I had to change because it was not checking properly the item Conjured. Also I tried to stick with a 3-5 hours work for this challenge, so a lot of things can be done better for future requirements. 
