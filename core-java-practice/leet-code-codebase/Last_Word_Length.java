class Last_Word_Length {

    public static int lengthOfLastWord(String s) {
        // Remove leading and trailing spaces
        s = s.trim();

        // Split the string by spaces
        String[] words = s.split(" ");

        // Return length of the last word
        return words[words.length - 1].length();
    }

    public static void main(String[] args) {
        String s = "Hello World   ";

        int result = lengthOfLastWord(s);

        System.out.println("Length of last word: " + result);
    }
}
