using System;

using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool userQuit = false;

        while (!userQuit)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    userQuit = true;
                    Console.WriteLine("\nKeep making progress on your Eternal Quest! Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select an option between 1 and 6.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        int playerLevel = (_score / 1000) + 1;
        string title = GetLevelTitle(playerLevel);

        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"[Level {playerLevel} - {title}]");
    }

    private string GetLevelTitle(int level)
    {
        return level switch
        {
            1 => "Novice Seeker",
            2 => "Apprentice Explorer",
            3 => "Determined Disciple",
            4 => "Valiant Knight",
            5 => "Master Champion",
            _ => "Eternal Legend"
        };
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals currently created.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("  No goals registered yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Bad Habit Goal (Negative Goal)");
        Console.Write("Which type of goal would you like to create? ");

        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        if (goalType == "4")
        {
            Console.Write("What is the point penalty when you indulge in this bad habit? ");
            if (int.TryParse(Console.ReadLine(), out int penalty))
            {
                _goals.Add(new BadHabitGoal(name, description, penalty));
                Console.WriteLine("Bad habit goal added.");
            }
            return;
        }

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type selected.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals available to record events for.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");

        if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex > 0 && selectedIndex <= _goals.Count)
        {
            Goal selectedGoal = _goals[selectedIndex - 1];

            if (selectedGoal.IsComplete())
            {
                Console.WriteLine("This goal has already been completed!");
                return;
            }

            selectedGoal.RecordEvent();

            if (selectedGoal is BadHabitGoal)
            {
                int penalty = selectedGoal.GetPoints();
                _score -= penalty;
                Console.WriteLine($"\nOh no! You succumbed to '{selectedGoal.GetShortName()}' and lost {penalty} points!");
            }
            else
            {
                int pointsEarned = selectedGoal.GetPoints();

                if (selectedGoal is ChecklistGoal checklistGoal)
                {
                    if (checklistGoal.IsComplete())
                    {
                        pointsEarned += checklistGoal.GetBonus();
                        Console.WriteLine($"\nCONGRATULATIONS! You completed the checklist goal and received a bonus of {checklistGoal.GetBonus()} points!");
                    }
                }

                _score += pointsEarned;
                Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points!");
            }

            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0) return;

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] mainParts = line.Split(':');
            string goalType = mainParts[0];
            string[] details = mainParts[1].Split(',');

            switch (goalType)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2]), bool.Parse(details[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[4]), int.Parse(details[3]), int.Parse(details[5])));
                    break;
                case "BadHabitGoal":
                    _goals.Add(new BadHabitGoal(details[0], details[1], int.Parse(details[2])));
                    break;
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}