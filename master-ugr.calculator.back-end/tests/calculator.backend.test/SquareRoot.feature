Feature: Square Root Calculation
	As Alice (the customer)
	I want to know the Square Root of this number.


Scenario Outline: Calculating the Square Root of the number
	Given a number <number> to calculate the Square Root
	When Square Root is calculated
	Then the answer is <result>
	Examples: 
	| number | result  |
	| 2      | 1.41    |
	| 3      | 1.73    |
	| 5      | 2.24    |
	| 7      | 2.65    |
	| 11     | 3.32    |
	| 997    | 31.57   |
	| 98689  | 314.15  |
	| 86743  | 294.52  |