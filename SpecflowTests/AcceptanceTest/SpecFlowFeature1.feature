Feature: SpecFlowFeature1
	As a skill trader I want to update my profile
	In order to update my profile 
	I want to add the languages that I know
	I want to add my Skills
	I want to add my Certification

@mytag
Scenario: Check if user could able to add a language 
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings

		
	Scenario: Check if user could able to add skills
	Given I clicked on the Skills tab under Profile page
	When I add a new Skills
	Then that skills should be displayed om my listing

	
	Scenario: Check if the user could able to add certification
	Given I clicked on the certification tab under Profile page
	When I add new certification
	Then that certification be displayed on my listing

	

	


	
