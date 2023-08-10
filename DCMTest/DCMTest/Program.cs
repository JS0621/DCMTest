//Sebastian Jazmin DIgital CM Software Engineer Coding Test
//Task: Create a console=based note-taking application using .NET Core
//Time Start: 8:05 PM

Console.Write("Note Taking Application:\n\n"); //Intro Message

bool go = true; //controls main menu loop
//Menu Loop
while (go)
{
    //Writing main menu to console
    Console.Write("1. Create a Note\n2. View All Notes\n3. Delete Note\n4. Exit\n\nInput Selection (1-4):  ");
    String user_input = Console.ReadLine();
    switch (user_input)
    {
        case "1":

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