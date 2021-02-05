package online.dev4you;

public class joinWords {
    public String joinWords(String[] words) {
        String sentence  = "";
        for (String w: words){
            sentence = sentence +w;
        }
        return sentence;
    }
}
