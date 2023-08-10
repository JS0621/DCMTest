//Sebastian Jazmin Digital CM Software Engineer Coding Test

//Task: Create a console=based note-taking application using .NET Core

//Time Start: 8:05 PM
//Time Finish: 12:00 AM

//Overview
/*
 * When I began, I decided I wanted to have notes save across sessions. Notes note saving accross sessions seems impractical.
 * I fixed this issue using .txt files.
 * Uses relative path from the exe in debug. Filepath can be changed to create the "notes" folder where specified.
 * Note application saves notes as .txts in the notes folder.
 * Note application can read and delete.
 */


using System.Text;
String notes_path = "..\\..\\..\\notes"; // Path for notes folder

Console.Write("Note Taking Application:\n\n"); //Intro Message

//Menu Loop
while (true)
{
    //Writing main menu to console
    Console.Write("\n1. Create a Note\n2. View All Notes\n3. Delete Note\n4. Exit\n\nInput Selection (1-4):  ");
    String? user_input = Console.ReadLine();
    switch (user_input)
    {
        case "1": //User wants to create a note
            //If notes folder does not exist, create it
            if (!Directory.Exists(notes_path))
            {
                Directory.CreateDirectory(notes_path);
            }
            String note_name = GetValidNoteName();

            Console.WriteLine("Input contents for " + note_name + " note:"); // Prompt for contents
            String? note_text = Console.ReadLine();// Read user input
            File.WriteAllText("..\\..\\..\\notes\\" + note_name + ".txt", note_name + ":\n" + note_text); //Create note file
            continue; //Return to main menu

        case "2": //User wants to read a note
            if (!Directory.Exists(notes_path))
            {
                Console.WriteLine("Notes folder does not exist, please create a note first");
                break;
            }
            List<String?>? existing_names = DisplayExistingNotes(); // Display note names and retrieve list of note names

            //loop for selecting which note to read
            while (true)
            {
                int user_selection = UserInputToInt();

                if (user_selection == -1)//-1 returns to menu
                {
                    break;
                }

                user_selection = user_selection - 1;
                //Check if selection is in range
                if (user_selection < 0 || user_selection > existing_names.Count() - 1)
                {
                    Console.WriteLine("Please select a number in range (or -1 to exit): ");
                }
                else
                {
                    //Print the note
                    string[] lines = File.ReadAllLines("..\\..\\..\\notes\\" + existing_names[user_selection], Encoding.UTF8);
                    Console.WriteLine(lines[0]); //Print name
                    //Loop to print rest of file
                    for (int i = 0; i++ < lines.Length; i++)
                    {
                        Console.WriteLine(lines[i]);
                    }
                }
                break;
            }

            continue;//Return to main menu
        case "3": //User wants to delete a note
            //If folder does not exist, no notes exist
            if (!Directory.Exists(notes_path)) 
            {
                Console.WriteLine("Notes folder does not exist, please create a note first");
                break;
            }

            //Delete loop
            while (true) 
            {
                List<String?>? existing_notes = DisplayExistingNotes();// Display note names and create list of note names


                Console.Write("Input exact name of note to delete or -1 to exit: ");
                String? note_to_delete = Console.ReadLine();
                if (String.IsNullOrEmpty(note_to_delete)) //is the input empty?
                {
                    Console.WriteLine("Input a listed name (or -1 to exit): ");
                }
                else if (note_to_delete == "-1") //is the input the exit
                {
                    break;
                }
                else if (existing_notes.Contains(note_to_delete))
                {
                    //Try catch as the file may be opened elsewhere
                    try
                    {
                        File.Delete(notes_path + "\\" + note_to_delete); //Delete the note
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    Console.WriteLine("Note successfully deleted");
                    break;
                }
                else
                {
                    Console.WriteLine("Input listed name (or -1 to exit): ");
                }
            }
            continue;

        case "4":
            break; //exit
        default:
            Console.Write("\nPlease Input a Valid Selection\n");
            continue;
    }
    break;
}
Console.Write("Thank you for using this app. Have a wonderful day!");

//Function to turn User Input to an int
int UserInputToInt()
{
    while (true)
    {
        Console.Write("Please input selection (or -1 to exit): ");
        if (int.TryParse(Console.ReadLine(), out int selection))
        {
            return selection;
        }
        else
        {
            Console.WriteLine("Please input an integer");
        }

    }
}

//Function to get a note name that is not a duplicate or null
String GetValidNoteName()
{
    String? note_name;
    while (true) //Loop for non null name
    {
        Console.Write("Input Note Name (must be unique): "); //prompt for name
        note_name = Console.ReadLine(); //Get Note Name
        if (!String.IsNullOrEmpty(note_name)) //Check for null
        {
            String filename = note_name + ".txt";// add .txt to compare to existing notes

            var existing_names = Directory.GetFiles(notes_path).Select(Path.GetFileName); //Grab all note names and put them into the var


            //Check if name is already in use
            if (existing_names.Contains(filename))
            {
                Console.WriteLine("Name already exists, please input a different name");
            }
            else
            {
                break;
            }


        }
        else
        {
            Console.WriteLine("Do not leave name blank");
            //return to top of loop
        }
    }

    return note_name;
}
//Display note names and save list of all note names
List<String?>? DisplayExistingNotes()
{
    //If notes folder does not exist, create it
    if (!Directory.Exists(notes_path))
    {
        Directory.CreateDirectory(notes_path);
    }

    Console.WriteLine("All Saved Notes:");// Intro

    List<String?>? existing_names = Directory.GetFiles(notes_path).Select(Path.GetFileName).ToList();//Get all note names

    //Write all note names
    for (int i = 0; i < existing_names.Count(); i++)
    {
        Console.WriteLine(i + 1 + ". " + existing_names[i]);
    }

    return existing_names;
}
