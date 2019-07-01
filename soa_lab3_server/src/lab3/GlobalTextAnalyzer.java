package lab3;


import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;

import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.xml.ws.Endpoint;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Objects;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

@WebService
public class GlobalTextAnalyzer {

    @WebMethod
    public Integer countOneWord(String text, String word){
        SimpleTuple[] tupleWords = this.countWords(text);
        for (SimpleTuple tuple : tupleWords){
            if (Objects.equals(tuple.key, word.toLowerCase()))
                return tuple.value;
        }
        return 0;
    }

    @WebMethod
    public SimpleTuple[] countCharacters(String text){
        HashMap<String, Integer> hashMap = new HashMap<>();
        for (int i =0;i<text.length();i++){
            String key = String.valueOf(text.charAt(i)).toLowerCase();
            int value = hashMap.getOrDefault(key, 0);
            hashMap.put(key, value+1);
        }
        return GlobalTextAnalyzer.mapToTuple(hashMap);
    }

    @WebMethod
    public SimpleTuple[] countWords(String text){
        Pattern wordsPattern = Pattern.compile("[a-zA-Z0-9_\\u0392-\\u03c9\\u0400-\\u04FF]+|[\\u4E00-\\u9FFF\\u3400-\\u4dbf\\uf900-\\ufaff\\u3040-\\u309f\\uac00-\\ud7af\\u0400-\\u04FF]+|[\\u00E4\\u00C4\\u00E5\\u00C5\\u00F6\\u00D6]+|\\w+");
        Matcher wordsMatcher = wordsPattern.matcher(text);
        HashMap<String, Integer> hashMap = new HashMap<>();
        while (wordsMatcher.find()){
            String key = wordsMatcher.group().toLowerCase();
            int value = hashMap.getOrDefault(key, 0);
            hashMap.put(key, value+1);
        }
        return GlobalTextAnalyzer.mapToTuple(hashMap);
    }

    @WebMethod
    public String makeCaps(String text){
        return text.toUpperCase();
    }

    @WebMethod
    public SimpleTuple[] countWordsOnWebPage(String url) throws IOException {
        Document doc = Jsoup.connect(url).get();
        String text = doc.text();
        return this.countWords(text);
    }

    private static SimpleTuple[] mapToTuple(HashMap<String, Integer> hashMap){
        ArrayList<SimpleTuple> result = new ArrayList<>();
        String[] keys = hashMap.keySet().toArray(new String[0]);
        Arrays.sort(keys);
        for(String key : keys){
            result.add(new SimpleTuple(key, hashMap.get(key)));
        }

        return result.toArray(new SimpleTuple[0]);
    }

    public static void main(String[] argv) {
        Object implementor = new GlobalTextAnalyzer();
        String address = "http://0.0.0.0:9000/GlobalTextAnalyzer";
        Endpoint.publish(address, implementor);
    }

}
