Feature: Sum
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@simple
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

@table
Scenario: Add two numbers with table
	Given I have entered the following
	| Operand1 | Operand2 |
	| 1        | 2        |
	| 2        | 3        |
	When I press add
	Then the result should be
	| Result   |
	| 3        |
	| 5        |

@examples
Scenario Outline: Add two numbers with examples
	Given I have entered <operand1> into the calculator
	And I have entered <operand2> into the calculator
	When I press add
	Then the result should be <result> on the screen

	Examples: 
	| operand1 | operand2 | result |
	| 3        | 4        | 7      |
	| 5        | 3        | 8      |
	| 5        | 5        | 10     |
	 