
// 백준 - 비밀번호 발음하기 4659
// https://www.acmicpc.net/problem/4659

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;

public class pronounce_password_4659 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringBuilder sb = new StringBuilder();
        ArrayList<String> vowelList = new ArrayList<>(Arrays.asList("a", "e", "i", "o", "u"));
        while (true) {
            String str = br.readLine();
            if (str.equals("end")) break;

            boolean isAcceptable = true;
            boolean vowel = false;
            int cCount = 1;
            int vCount = 1;
            for (int i = 0; i < str.length(); i++) {
                String cur = str.charAt(i)+"";
                if (vowelList.contains(cur)) vowel = true;

                if (i >= 1) {
                    String prev = str.charAt(i-1) + "";
                    if (vowelList.contains(prev) && vowelList.contains(cur)) vCount++;
                    else if (!vowelList.contains(prev) && !vowelList.contains(cur)) cCount++;
                    else {
                        vCount = 1;
                        cCount = 1;
                    }
                }

                if (cCount >= 3 || vCount >= 3) {
                    isAcceptable = false;
                    break;
                }

                if (i >= 1 && cur.equals(str.charAt(i-1)+"")) {
                    if (!cur.equals("e") && !cur.equals("o")) {
                        isAcceptable = false;
                        break;
                    }
                }
            }
            if (!vowel) isAcceptable = false;

            sb.append("<").append(str).append("> is ");
            sb.append((isAcceptable) ? "acceptable." : "not acceptable.").append("\n");
        }
        System.out.println(sb);
    }
}
