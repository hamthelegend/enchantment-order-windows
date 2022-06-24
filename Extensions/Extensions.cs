namespace Extensions;

public static class Extension {
    
    // From https://www.c-sharpcorner.com/article/convert-numbers-to-roman-characters-in-c-sharp/
    public static string ToRomanNumerals(this int arabic)
    {
        var roman = string.Empty;
        string[] romanLetters = {
            "M",
            "CM",
            "D",
            "CD",
            "C",
            "XC",
            "L",
            "XL",
            "X",
            "IX",
            "V",
            "IV",
            "I"
        };
        int[] numbers = {
            1000,
            900,
            500,
            400,
            100,
            90,
            50,
            40,
            10,
            9,
            5,
            4,
            1
        };
        var i = 0;
        while (arabic != 0) {
            if (arabic >= numbers[i]) {
                arabic -= numbers[i];
                roman += romanLetters[i];
            } else {
                i++;
            }
        }
        return roman;
    }
    
}