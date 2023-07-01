// Drofsnar the Bird Man
// Console.WriteLine(Environment.CurrentDirectory);
// Starting with the file
string path = "./game-sequence.txt";
string fileText = File.ReadAllText(path);
// Console.WriteLine(fileText);
int score = 5000;
int birdHunterScore = 200;
int lives = 3;

string[] events = fileText.Split(',');

Dictionary<string, int> scores = new Dictionary<string, int>()
{
    { "Bird", 10 },
    { "EveningGrosbeak", 1000 }
    // etc...
};  // this is one option

// Once you have the score calculated, format your output - spacing, colors, ?
// Slack me when you think you have the score!!
// Or if you're not sure what to do next!!

foreach(string bird in events)
{
    // switch (bird) { or...
    if (bird == "Bird") score += 10;
    else if (bird == "CrestedIbis") score += 100;
    else if (bird == "GreatKiskudee") score += 300;
    else if (bird == "RedCrossbill") score += 500;
    else if (bird == "Red-neckedPhalarope") score += 700;
    else if (bird == "EveningGrosbeak") score += 1000;
    else if (bird == "GreaterPrairieChicken") score += 2000;
    else if (bird == "Orange-belliedParrot") score += 5000;
    else if (bird == "VulnerableBirdHunter")
    {
        // score += hunter score
        // multiply hunter score by 2
    }
    else if (bird == "InvincibleBirdHunter")
    {
        // Take away 1 life
    }

    // if lives == 0 you dead (stop looping - final score reached)

    // OR get an extra life here, maybe?


    // OR switch (bird) {

    Console.WriteLine($"Event: {bird, -24}  Score: {score}");

    Thread.Sleep(50);
}




// Eventually... Calculate the final score of the game
// YOU ARE NOT RE-CREATING THE WHOLE GAME
// Just calculating the score from the text file

// Use classes if necessary?? Or just loops/if/then/etc

// Write Pseudocode!!!

// Use the Console to see the effect of your code