/**
*	Grading ID:	L8486
*	Program:	1
*	Date due:	9/24/19
*	Course:		CIS199-72
*	Description:	This program is a console application that declares variables, accepts user input, calculates gallons of paint needed to cover walls in a room, then displays output.
**/

using System;
using static System.Console;

namespace Program1
{
	class Program
	{
		private const int	DOOR_AREA = 21,		    // SqFt of doors
					        WINDOW_AREA = 12,	    // SqFt of windows
					        PAINT_COVERAGE = 400;   // Amount of SqFt a gallon of paint covers

		// Main method that declares variables, accepts user input, calculates gallons of paint needed to cover walls in a room, then displays output
		static void Main(string[] args)
		{
			// Variables
			double	perimeter,  	// Length x Width of room
			    	height,		    // Height of room
			    	totalArea,	    // Calculated total area of room in SqFt
			    	paintableArea,	// Calculated paintable area of the room, accounting for room's features
			    	gallonsNeeded;	// Calculated gallons of paint needed to cover paintable area

			int	doors,			    // Amount of doors in room
				windows,	    	// Amount of windows in room
				coats,			    // Amount of coats needed for room
				gallonsNeededToBuy;	// Amount of whole gallons needed to purchase

			try
			{
				// Input
				WriteLine("== Paint calculator ==\n");
				Write("Enter total length of all walls (in feet): ");
				perimeter = double.Parse(ReadLine());
				Write("Enter the height of the walls (in feet): ");
				height = double.Parse(ReadLine());
				Write("Enter the number of doors: ");
				doors = int.Parse(ReadLine());
				Write("Enter the number of windows: ");
				windows = int.Parse(ReadLine());
				Write("Enter the number of coats of paint: ");
				coats = int.Parse(ReadLine());
				WriteLine("");

				// Input validation
				Exception valError = new Exception("One or more values are invalid.");
				if (perimeter <= 0 || height <= 0 || coats <= 0 || doors < 0 || windows < 0) { throw valError; }    // An alternative to this, is TryParse for each input to catch the invalid input when entered
		
				// Calculations
				totalArea = perimeter * height;
				paintableArea = (totalArea - (windows * WINDOW_AREA) - (doors * DOOR_AREA)) * coats;
				gallonsNeeded = paintableArea / PAINT_COVERAGE;
				gallonsNeededToBuy = (int)Math.Ceiling(gallonsNeeded);

                // Calculations validation
                if (totalArea <= 0 || paintableArea <=0 || gallonsNeeded <= 0 || gallonsNeededToBuy <= 0) { throw valError; }   // A calculation returned a value that doesn't make sense
		
				// Output
				WriteLine($"You need a minimum of {gallonsNeeded:f1} gallons of paint");
				WriteLine($"You'll need to buy {gallonsNeededToBuy} gallons, though");
                // Added following 2 lines so it is a standalone, and able to run outside a debugging environment.
                WriteLine("Press any key to exit . . .");
				ReadKey();
			}
			catch(Exception exp)
			{
				WriteLine($"Error! {exp.Message}\n" +
                    // Ascii art below:
                    "                                                         \n                       .,*******,.                       \n                 ,***,,,.........,,,***,                 \n              ***,,.                 .,,***              \n           ,**,,                         ,,**.           \n         ***,.                             .,***         \n       ,/*,..                               ..,*/,       \n      ***,....                            ......***      \n     /**,..........                   ..........,**/     \n    //*,,....*%&%&% ....         ...../&%&&/,...,,*//    \n   ,/**,,,,/%%%*.........................,#%%#,,,,,*/,   \n   //*,,,*%%#.,*/(##(*,............,****,,..(%%/,,,*//   \n  *//**,,%%,/%%%%####%%%%,.....,#&%%%%%%%%*.#%,,**//,  \n  ///***,,,,%%%#((/#..,/%#.....%%#(/*#(((#%%%,,,,***///  \n  (//***,,,,#,*****#,,.............,,(*****,#,,,,***//(  \n  /(/****,,,#******#,,,,.........,,,,(******#,,,****/(/  \n  *(//***,,,#******#,,,,,,,,,,,,,,,,,(******#,,,***//(,  \n   ((//****,#******#,,,,,(%%#%%/,,,,*(******#,****//((   \n   ,(//*****#*/****#,,,/#,.   .*%*,,*(****/*#*****//(,   \n    ((//****#////**#*,*%*,.   .,*%,,*(**////#****//((    \n     ((///**#/////*#*,/%%%%%%%%%%%*,*(*/////#**///((     \n      /((///#(((///#*,/%#########%*,/#///(((#*//((/      \n       ,(((/#(((((/#/**%##########**/#/(((((#/(((.       \n         /((%##((((#/***(%#####%/***/#(((###%((/         \n           ,%%######/******,,,******/######%%.           \n              #%%##%(///////////////(%#%%%(              \n                 *%%(((((///////(((((%#*                 \n                       .,//(((//,.                     ");
                // Added following 2 lines so it is a standalone, and able to run outside a debugging environment.
                WriteLine("Press any key to display more detailed debug information . . .");
                ReadKey();
                WriteLine($"\nDebug information:\n{exp}");
                WriteLine("Press any key to exit . . .");
                ReadKey();
			}
		}
			
	}
}
