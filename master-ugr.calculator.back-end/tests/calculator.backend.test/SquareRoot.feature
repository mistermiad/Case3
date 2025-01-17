Feature: Square Root Calculation
	As Alice (the customer)
	I want to know the Square Root of this number.


Scenario Outline: Calculating the Square Root of the number
	Given a number <number> to calculate the Square Root
	When Square Root is calculated
	Then the answer of the square root is <result>
	Examples: 
	| number | result              |
	| 2      | 1.4142135623730951  |
	| 3      | 1.7320508075688772  |
	| 5      | 2.23606797749979    |
	| 7      | 2.6457513110645907  |
	| 11     | 3.3166247903554     |
	| 997    | 31.575306807693888  |
	| 98689  | 314.14805426741066  |
	| 86743  | 294.5216460635788   |