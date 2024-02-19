# Backend Tasks Project

This project contains two main tasks aimed at showcasing object-oriented programming, file reading, and basic taxation calculations.

## Task 1: MovieStar Class Application

### Description

The application reads data from the "Input.txt" file to create instances of a `MovieStar` class with properties assigned from the file. It displays each `MovieStar`'s properties in the console and calculates their ages. Additionally, it filters and shows all female persons from China born after January 1, 1996, and calculates the average age of all male persons.

### Requirements:

- Read "Input.txt" and parse its content.
- Create a `MovieStar` class with relevant properties.
- Instantiate `MovieStar` objects and assign them properties from the file.
- Display each `MovieStar`'s properties and calculate their current age.
- Filter female `MovieStars` from China born after 01.01.1996 and display them.
- Calculate and display the average age of male `MovieStars`.

#### Design Pattern 

For this task, the Factory Pattern could be useful to encapsulate the creation logic for `MovieStar` instances. This would separate file parsing and object creation responsibilities.

## Task 2: Net Salary Calculator Application

### Description

A console application that calculates the net salary based on gross income according to Imaginaria's tax policy. The application processes the input gross value and applies appropriate tax and social contribution deductions.

### Taxation Rules in Imaginaria

1. No taxation for amounts lower or equal to 1000 IDR.
2. Income tax of 10% is applied to any amount above 1000 IDR.
3. Social contributions of 15% are due on the amount above 1000 IDR but only up to 3000 IDR.

### Example Calculations

- **Example 1:** George has a salary of 980 IDR; he pays no taxes and takes home 980 IDR.
- **Example 2:** Irina has a salary of 3400 IDR; she pays 240 IDR in income tax and 300 IDR in social contributions. She takes home 2860 IDR.

### Instructions

To fulfill the requirements of tasks 1 and 2:

1. Develop the `MovieStar` class application as per task 1 details.
2. Implement the Net Salary Calculator application according to the taxation rules provided for task 2.
3. Ensure code quality by following best practices and principles.
4. Apply a convenient design pattern for task 1 if deemed necessary.