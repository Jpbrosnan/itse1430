/*
 * ITSE 1430
 * Adventure Game
 * Name: Jonathan Brosnan
 * Lab 3 Final
 * 10/31/2023
 */

namespace JonathanBrosnan.AdventureGame.WinHost;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main ()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}