Imports System.Numerics

Namespace Operations.BruteForcePasswordGenerator
    Public Class BruteForcePasswordGenerator
        Public Sub Run()
            GeneratePassword()
        End Sub

        Private Sub GeneratePassword()
            Dim chars() As Char = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            Dim passwordLength As Short = 0

            Console.Write("Enter the password length: ")

            passwordLength = Convert.ToInt32(Console.ReadLine())

            ' Double casts were redundant
            Dim iPossibilities As BigInteger = CType(Math.Pow(chars.Length, passwordLength), BigInteger)
            Console.Write("{0} words total. Press ENTER to continue;", iPossibilities)
            Console.ReadLine()

            Dim watch As Stopwatch = Stopwatch.StartNew()

            For i As BigInteger = 0 To iPossibilities - 1
                Dim theWord As String = ""
                Dim val As BigInteger = i
                For j As Short = 0 To passwordLength - 1
                    Dim ch As BigInteger = (val Mod chars.Length)
                    theWord = chars(CType(ch, Short)) + theWord
                    val = val / chars.Length
                Next

                Console.WriteLine(theWord)
            Next

            watch.Stop()
            Dim elapsedMs As Long = watch.ElapsedMilliseconds
            Console.WriteLine("It took {0} milliseconds ({1} seconds) to generate {2} possible combinations", elapsedMs, elapsedMs / 1000, iPossibilities)
        End Sub
    End Class
End Namespace
