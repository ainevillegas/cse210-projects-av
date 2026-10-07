/*
W06 Project: Eternal Quest Program

Creativity and Exceeding Requirements:

This program includes a player level system as an additional
gamification feature. The player's level increases as the player's
total score increases.

The levels are:
Level 1 - Beginner
Level 2 - Rising Adventurer
Level 3 - Goal Warrior
Level 4 - Quest Master
Level 5 - Eternal Champion

The program displays the player's current level together with the
score. It also prevents completed simple and checklist goals from
awarding points more than intended. Input validation and helpful
error messages were added to prevent invalid menu and goal choices.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}