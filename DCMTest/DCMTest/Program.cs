//Sebastian Jazmin DIgital CM Software Engineer Coding Test
//Task: Create a console=based note-taking application using .NET Core
//Time Start: 8:05 PM

Console.Write("Note Taking Application:\n\n"); //Intro Message


String notes_path = "..\\..\\..\\notes"; // Path for notes folder

bool go = true; //controls main menu loop
//Menu Loop
while (go)
{
    //Writing main menu to console
    Console.Write("1. Create a Note\n2. View All Notes\n3. Delete Note\n4. Exit\n\nInput Selection (1-4):  ");
    String? user_input = Console.ReadLine();
    switch (user_input)
    {
        case "1": //User wants to create a note

            String note_name = GetValidNoteName();

            Console.WriteLine("Input contents for " + note_name + " note:"); // Prompt for contents
            String? note_text = Console.ReadLine();// Read user input
            File.WriteAllText("..\\..\\..\\notes\\" + note_name + ".txt", note_name + ":\n" + note_text); //Create note file
            break;

        case "2":

            break;
        case "3":

            break;
        case "4":
            go = false;
            break;
        default:
            Console.Write("\nPlease Input a Valid Selection\n");
            break;
    }
}

Console.Write("Thank you for using this app. Have a wonderful day!");


String GetValidNoteName()
{
    //Function to get a note name that is not a duplicate or null

    String? note_name;
    while (true) //Loop for non null name
    {
        Console.Write("Input Note Name (must be unique): "); //prompt for name
        note_name = Console.ReadLine(); //Get Note Name
        if (!String.IsNullOrEmpty(note_name)) //Check for null
        {
            String filename = note_name + ".txt";// add .txt to compare to existing notes

            //If notes folder does not exist, create it
            if (!Directory.Exists(notes_path))
            {
                Directory.CreateDirectory(notes_path);
            }

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