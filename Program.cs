using System;
using System.Collections.Generic;
using FinchAPI;
using System.IO;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control
    // Description: An application that has the user control
    // a finch robot.
    // Application Type: Console
    // Author: Sortzi, Sammi
    // Dated Created: 10/2/2019
    // Last Modified: 11/6/2019
    //
    // **************************************************

    class Program
    {
        public enum Command
        {
            NONE,
            MOVEFORWARD,
            MOVEBACKWARD,
            STOPMOTORS,
            WAIT,
            TURNRIGHT,
            TURNLEFT,
            LEDON,
            LEDOFF,
            DONE
        }

        static void Main(string[] args)
        {

            DisplayWelcomeScreen();
            DisplayMainMenu();
            DisplayClosingScreen();
        }


        static void DisplayMainMenu()
        {
            //
            // instantiate (create) a Finch object
            //
            Finch finchRobot = new Finch();

            bool finchRobotConnected = false;
            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get menu choice from user
                //
                Console.WriteLine("a) Connect Finch Robot");
                Console.WriteLine("b) Talent Show");
                Console.WriteLine("c) Data Recorder");
                Console.WriteLine("d) Alarm System");
                Console.WriteLine("e) User Programming");
                Console.WriteLine("f) Disconnect Finch Robot");
                Console.WriteLine("q) Quit");
                Console.WriteLine("Enter Choice:");
                menuChoice = Console.ReadLine().ToUpper();

                //
                // process menu choice
                //
                switch (menuChoice)
                {
                    case "A":
                        finchRobotConnected = DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "B":
                        if (finchRobotConnected)
                        {
                            DisplayTalentShow(finchRobot);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Finch robot not connected. Return to Main Menu and connect.");
                            DisplayContinuePrompt();
                        }
                        break;

                    case "C":
                        if (finchRobotConnected)
                        {
                            DisplayDataRecorder(finchRobot);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Finch robot not connected. Return to Main Menu and connect.");
                            DisplayContinuePrompt();
                        }
                        break;

                    case "D":
                        if (finchRobotConnected)
                        {
                            DisplayAlarmSystem(finchRobot);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Finch robot not connected. Return to Main Menu and connect.");
                            DisplayContinuePrompt();
                        }
                        break;

                    case "E":
                        if (finchRobotConnected)
                        {
                            DisplayUserProgramming(finchRobot);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Finch robot not connected. Return to Main Menu and connect.");
                            DisplayContinuePrompt();
                        }
                        break;

                    case "F":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "Q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine("\t ***************************");
                        Console.WriteLine("\t Please enter a menu choice.");
                        Console.WriteLine("\t ***************************");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);

        }

        static void DisplayTalentShow(Finch finchRobot)
        {
            string talentChoice;

            DisplayScreenHeader("Talent Show");

            Console.WriteLine("Finch robot is ready to show you their talent.");
            DisplayContinuePrompt();

            Console.WriteLine("a) Finch Song");
            Console.WriteLine("b) Finch Dance");
            Console.WriteLine("c) Exit to main menu");
            talentChoice = Console.ReadLine().ToUpper();

            switch (talentChoice)
            {
                case "A":
                    Console.WriteLine("Finch will sing you a song.");
                    

                    finchRobot.noteOn(784);
                    finchRobot.wait(500);
                    finchRobot.noteOn(784);
                    finchRobot.wait(250);
                    finchRobot.noteOn(880);
                    finchRobot.wait(500);
                    finchRobot.noteOn(784);
                    finchRobot.wait(250);
                    finchRobot.noteOn(1047);
                    finchRobot.wait(250);
                    finchRobot.noteOn(988);
                    finchRobot.wait(1000);

                    finchRobot.noteOn(784);
                    finchRobot.wait(375);
                    finchRobot.noteOn(784);
                    finchRobot.wait(375);
                    finchRobot.noteOn(880);
                    finchRobot.wait(500);
                    finchRobot.noteOn(784);
                    finchRobot.wait(250);
                    finchRobot.noteOn(587);
                    finchRobot.wait(250);
                    finchRobot.noteOn(523);
                    finchRobot.wait(1000);
                    finchRobot.noteOff();
                     break;

                case "B":
                    Console.WriteLine("Finch will do a dance.");
                    

                    finchRobot.setLED(255, 0, 0);
                    finchRobot.setMotors(150, 150);
                    finchRobot.wait(500);
                    finchRobot.setMotors(150, 0);
                    finchRobot.wait(250);
                    finchRobot.setMotors(0, -150);
                    finchRobot.wait(250);
                    finchRobot.setMotors(0, 0);
                    finchRobot.wait(500);
                    finchRobot.setLED(0, 255, 0);
                    finchRobot.setMotors(-75, -75);
                    finchRobot.wait(500);
                    finchRobot.setMotors(150, 150);
                    finchRobot.wait(250);
                    finchRobot.setMotors(0, 0);
                    finchRobot.wait(500);
                    finchRobot.setLED(0, 0, 255);
                    finchRobot.setMotors(-50, 0);
                    finchRobot.setMotors(75, 75);
                    finchRobot.wait(500);
                    finchRobot.setMotors(150, 75);
                    finchRobot.wait(250);
                    finchRobot.wait(500);
                    finchRobot.setMotors(0, 0);
                    finchRobot.wait(500);
                    break;

                case "C":
                    DisplayContinuePrompt();
                    break;

                default:
                    Console.WriteLine("\t ***************************");
                    Console.WriteLine("\t Please enter a menu choice.");
                    Console.WriteLine("\t ***************************");
                    DisplayContinuePrompt();
                    break;
            }

            DisplayContinuePrompt();
        }

        static void DisplayDataRecorder(Finch finchRobot)
        {
            double dataPointFrequency;
            int numberOfDataPoints;

            DisplayScreenHeader("Data Recorder");

            Console.WriteLine("You are going to input the frequency of the data and the time inbetween.");

            dataPointFrequency = DisplayGetDataPointFrequency();
            numberOfDataPoints = DisplayGetNumberOfDataPoints();

            //
            // instantiate (create) the array
            //
            double[] temperatures = new double[numberOfDataPoints];

            DisplayGetData(numberOfDataPoints, dataPointFrequency, temperatures, finchRobot);

            DisplayData(temperatures);
         
            DisplayMainMenuPrompt();
        }

        static void DisplayData(double[] temperatures)
        {
            DisplayScreenHeader("Temperature Data");

            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine($"Temperature {index + 1}: {temperatures[index]}");
            }

            DisplayContinuePrompt();
        }



        static void DisplayGetData(
            int numberOfDataPoints, 
            double dataPointFrequency, 
            double[] temperatures, 
            Finch finchRobot)
        {
            DisplayScreenHeader("Get Temperature Data");

            Console.WriteLine("The finch robot is going to tell you the temperature in degrees Celsius.");
            for (int index = 0; index < numberOfDataPoints; index++)
            {
                //
                // record data
                //
               temperatures[index] = finchRobot.getTemperature();
                int milliseconds = (int)(dataPointFrequency * 1000);
                finchRobot.wait(milliseconds);

                //
                // echo data
                //
                Console.WriteLine($"Temperature {index + 1}: {temperatures[index]}");
            }

            DisplayContinuePrompt();
        }

        static int DisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;

            DisplayScreenHeader("Number of Data Points");

            Console.Write("Enter Number of Data Points:");
            int.TryParse(Console.ReadLine(), out numberOfDataPoints);

            DisplayContinuePrompt();

            return numberOfDataPoints;
        }

        static double DisplayGetDataPointFrequency()
        {
            double dataPointFrequency;
            //string userResponse;

            DisplayScreenHeader("Data Point Frequency");

            Console.Write("Enter Data Point Frequency");
            //userResponse = Console.ReadLine();
            //double.TryParse(userResponse, out dataPointFrequency);
            double.TryParse(Console.ReadLine(), out dataPointFrequency);

            DisplayContinuePrompt();

            return dataPointFrequency;
        }
        #region ALARM SYSTEM
        static void DisplayAlarmSystem(Finch finchRobot)
        {
            string alarmType;
            int maxSeconds;
            double threshold;
            bool thresholdExceeded;

            DisplayScreenHeader("Alarm System");

            alarmType = DisplayGetAlarmType();
            maxSeconds = DisplayGetMaxSeconds();
            threshold = DisplayGetThreshold(finchRobot, alarmType);

            Console.WriteLine("The finch robot is going to monitor light and temperatures.");
            

            thresholdExceeded = MonitorCurrentLightLevel(finchRobot, threshold, maxSeconds);

            if (alarmType == "light")
            {
                thresholdExceeded = MonitorCurrentLightLevel(finchRobot, threshold, maxSeconds);

                if (thresholdExceeded)
                {
                    if (alarmType == "light")
                    {
                        Console.WriteLine("Maximum Light Level Exceeded");
                    }
                    else
                    {
                        Console.WriteLine("Maximum Temperature Level Exceeded");
                    }

                }
                else
                {
                    Console.WriteLine("Maximum Monitoring Time Exceeded");
                }
            }

            if (alarmType == "temperature")
            {
                thresholdExceeded = MonitorCurrentTemperatureLevel(finchRobot, threshold, maxSeconds);

                if (thresholdExceeded)
                {
                    if (alarmType == "light")
                    {
                        Console.WriteLine("Maximum Light Level Exceeded");
                    }
                    else
                    {
                        Console.WriteLine("Maximum Temperature Level Exceeded");
                    }

                }
                else
                {
                    Console.WriteLine("Maximum Monitoring Time Exceeded");
                }
            }

            DisplayMainMenu();
        }

        static bool MonitorCurrentTemperatureLevel(Finch finchRobot, double threshold, int maxSeconds)
        {
            bool thresholdExceeded = false;
            double currentTempLevel;
            double seconds = 0;

            while (!thresholdExceeded && seconds <= maxSeconds)
            {
                currentTempLevel = finchRobot.getTemperature();

                DisplayScreenHeader("Monitoring Temp Levels");
                Console.WriteLine($"Maximum Temp Level: {threshold}");
                Console.WriteLine($"Current Temp Level: {currentTempLevel}");

                if (currentTempLevel > threshold)
                {
                    thresholdExceeded = true;
                    Console.WriteLine("Threshold has been exceeded!");
                    DisplayContinuePrompt();
                }

                finchRobot.wait(500);
                seconds += 0.5;
            }

            return thresholdExceeded;
        }

        static bool MonitorCurrentLightLevel(Finch finchRobot, double threshold, int maxSeconds)
        {
            bool thresholdExceeded = false;
            int currentLightLevel;
            double seconds = 0;

            while (!thresholdExceeded && seconds <= maxSeconds)
            {
                currentLightLevel = finchRobot.getLeftLightSensor();

                DisplayScreenHeader("Monitoring Light Levels");
                Console.WriteLine($"Maximum Light Level: {threshold}");
                Console.WriteLine($"Current Light Level: {currentLightLevel}");

                if (currentLightLevel > threshold)
                {
                    thresholdExceeded = true;
                    Console.WriteLine("Threshold has been exceeded!");
                    DisplayContinuePrompt();
                }

                finchRobot.wait(500);
                seconds += 0.5;
            }

            return thresholdExceeded;
        }

        static double DisplayGetThreshold(Finch finchrobot, string alarmType)
        {
            double threshold = 0;
            bool valid = true;
            DisplayScreenHeader("Threshold Value");

            switch (alarmType)
            {
                case "light":

                    do
                    {
                        Console.Write($"Current Light Level: {finchrobot.getLeftLightSensor()}");
                        Console.WriteLine();
                        Console.Write("Enter Maximum Light Level [0-255]:");
                        threshold = double.Parse(Console.ReadLine());
                        if (threshold > 255)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter a number between 0 and 255.");
                        }
                    } while (!valid);
                    
                    break;

                case "temperature":
                    Console.Write($"Current Temperature: {finchrobot.getTemperature()}");
                    Console.WriteLine();
                    Console.WriteLine("Enter Maximum Temperature.");
                    threshold = double.Parse(Console.ReadLine());
                    break;

                default:
                    break;
            }

            DisplayContinuePrompt();

            return threshold;
        }

        static int DisplayGetMaxSeconds()
        {
            int maxSeconds;
            string input;
            bool valid = false;
            do
            {
                Console.WriteLine("Enter Maximum Number of Seconds:");
                input = Console.ReadLine();

                if (!int.TryParse(input, out maxSeconds))
                {
                    Console.WriteLine("Please enter a valid number.");
                }
                else
                {
                    Console.WriteLine($"The finch robot will monitor for {maxSeconds} seconds.");
                    valid = true;
                    DisplayContinuePrompt();
                }

            } while (!valid);
            

            return maxSeconds;
        }

        static string DisplayGetAlarmType()
        {

            Console.Write("Enter Alarm Type [light or temperature]:");
            return Console.ReadLine();
        }

        #endregion

        #region UserProgramming
        static void DisplayUserProgramming(Finch finchRobot)
        {
            string menuChoice;
            bool quitApplication = false;

            (int motorSpeed, int ledBrightness, int waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            List<Command> commands = new List<Command>();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get menu choice from user
                //
                Console.WriteLine("a) Set Command Parameters");
                Console.WriteLine("b) Add Commands");
                Console.WriteLine("c) View Commands");
                Console.WriteLine("d) Execute Commands");
                Console.WriteLine("e) Save Commands to Text File");
                Console.WriteLine("f) Load Commands from Text File");
                Console.WriteLine("q) Quit");
                Console.WriteLine("Enter Choice:");
                menuChoice = Console.ReadLine().ToUpper();

                //
                // process menu choice
                //
                switch (menuChoice)
                {
                    case "A":
                        commandParameters = DisplayGetCommandParameters();
                        break;

                    case "B":
                        DisplayGetFinchCommands(commands);
                        break;

                    case "C":
                        DisplayFinchCommands(commands);
                        break;

                    case "D":
                        DisplayExecuteCommands(finchRobot, commands, commandParameters);
                        break;

                    case "E":
                        DisplayWriteUserProgrammingData(commands);
                        break;

                    case "F":
                        commands = DisplayReadUserProgrammingData();
                        break;

                    case "Q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine("\t ***************************");
                        Console.WriteLine("\t Please enter a menu choice.");
                        Console.WriteLine("\t ***************************");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);

        }

        static List<Command> DisplayReadUserProgrammingData()
        {
            string dataPath = @"Data\Data.txt";
            List<Command> commands = new List<Command>();
            string[] commandsString;

            DisplayScreenHeader("Read Commands from Data File");

            Console.WriteLine("Ready to read commands from the data file.");
            Console.WriteLine();

            commandsString = File.ReadAllLines(dataPath);

            Command command;
            foreach (string commandString in commandsString)
            {
                Enum.TryParse(commandString, out command);

                commands.Add(command);
            }


            Console.WriteLine();
            Console.WriteLine("Commands read from data file.");

            DisplayContinuePrompt();

            return commands;
        }

        static void DisplayWriteUserProgrammingData(List<Command> commands)
        {
            string dataPath = @"Data\Data.txt";
            List<string> commandsString = new List<string>();

            DisplayScreenHeader("Write Commands to Data File");

            //
            // create a list of command strings
            //
            foreach (Command command in commands)
            {
                commandsString.Add(command.ToString());
            }

            Console.WriteLine("Ready to write to the data file.");
            DisplayContinuePrompt();

            File.WriteAllLines(dataPath, commandsString.ToArray());

            Console.WriteLine();
            Console.WriteLine("Commands written to the data file.");

            DisplayContinuePrompt();
        }

        static void DisplayExecuteCommands(
            Finch finchRobot, 
            List<Command> commands,
            (int motorSpeed, int ledBrightness, int waitSeconds) commandParameters)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int waitMilliSeconds = commandParameters.waitSeconds * 1000;

            DisplayScreenHeader("Execute Finch Commands");

            // info and pause

            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;
                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(motorSpeed, motorSpeed);
                        break;
                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        break;
                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        break;
                    case Command.WAIT:
                        finchRobot.wait(waitMilliSeconds);
                        break;
                    case Command.TURNRIGHT:
                        finchRobot.setMotors(motorSpeed, 0);
                        break;
                    case Command.TURNLEFT:
                        finchRobot.setMotors(0, motorSpeed);
                        break;
                    case Command.LEDON:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        break;
                    case Command.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        break;
                    case Command.DONE:
                        break;
                    default:
                        break;
                }
            }

            DisplayContinuePrompt();
        }

        static void DisplayFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Display Finch Commands");

            foreach (Command command in commands)
            {
                Console.WriteLine(command);
                
            }
            DisplayContinuePrompt();
        }

        static void DisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;
            string userResponse;

            DisplayScreenHeader("Finch Robot Commands");

            while (command != Command.DONE)
            {
                Console.Write("Enter Command:");
                userResponse = Console.ReadLine().ToUpper();
                Enum.TryParse(userResponse, out command);

                commands.Add(command);


            }
            DisplayContinuePrompt();
        }

        static (int motorSpeed, int ledBrightness, int waitSeconds) DisplayGetCommandParameters()
        {
            (int motorSpeed, int ledBrightness, int waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;
            bool valid = false;
            string input;

            DisplayScreenHeader("Command Parameters");

            do
            {

                Console.Write("Enter Motor Speed [1 - 255]:");
                input = Console.ReadLine();

                if (!int.TryParse(input, out commandParameters.motorSpeed))
                {
                    Console.WriteLine("Please enter a valid number between 1 and 255.");
                    valid = false;

                }
                if (commandParameters.motorSpeed > 255)
                {
                    commandParameters.motorSpeed = 255;
                    valid = false;
                }
                if (commandParameters.motorSpeed < 1)
                {
                    commandParameters.motorSpeed = 1;
                    valid = false;
                }
                else
                {
                    valid = true;
                }


            } while (!valid);

            do
            {

                Console.Write("Enter LED Brightness [1 - 255]:");
                input = Console.ReadLine();

                if (!int.TryParse(input, out commandParameters.ledBrightness))
                {
                    Console.WriteLine("Please enter a valid number between 1 and 255.");
                    valid = false;
                }
                if (commandParameters.ledBrightness > 255)
                {
                    commandParameters.ledBrightness = 255;
                    valid = true;
                }
                if (commandParameters.ledBrightness < 1)
                {
                    commandParameters.ledBrightness = 1;
                    valid = true;
                }
                else
                {
                    valid = true;
                }
            } while (!valid);

            do
            {

                Console.Write("Enter Wait Time in Seconds:");
                input = Console.ReadLine();

                if (!int.TryParse(input, out commandParameters.waitSeconds))
                {
                    Console.WriteLine("Please enter a valid number.");

                }
            } while (!valid);

            DisplayContinuePrompt();

            return commandParameters;
        }
        #endregion

        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("Ready to disconnect the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine();
            Console.WriteLine("Finch robot is now disconnected.");

            DisplayContinuePrompt();
        }

        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            bool finchRobotConnected = false;

            DisplayScreenHeader("Connect to Finch Robot");

            Console.WriteLine("Ready to connect to the Finch robot. Be sure to connect the USB cable to the robot and computer");
            DisplayContinuePrompt();

            finchRobotConnected = finchRobot.connect();

            if (finchRobotConnected)
            {
                finchRobot.setLED(0, 255, 0);
                finchRobot.noteOn(15000);
                finchRobot.wait(1000);
                finchRobot.noteOff();

                Console.WriteLine();
                Console.WriteLine("Finch Robot is now connected");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Unable to connect to the Finch robot.");
            }
            DisplayContinuePrompt();

            return finchRobotConnected;
        }

        /// <summary>
        /// display welcome screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        #region HELPER METHODS

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display main menu prompt
        /// </summary>
        static void DisplayMainMenuPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the Main Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
