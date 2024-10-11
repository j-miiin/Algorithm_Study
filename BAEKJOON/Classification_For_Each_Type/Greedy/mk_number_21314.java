package baekjoon.greedy;

// 백준 - 21314 민겸 수
// https://www.acmicpc.net/problem/21314

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class mk_number_21314 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        String originNum = br.readLine();

        String max = getMaxNum(originNum);
        String min = getMinNum(originNum);
        System.out.println(max + "\n" + min);
    }

    public static String getMaxNum(String str) {
        String result = "";

        int length = str.length();
        int mCount = 0;
        for (int i = 0; i < length; i++) {
            String cur = str.charAt(i) + "";
            if (cur.equals("M")) mCount++;
            else {
                if (mCount > 0) {
                    result += "5";
                    for (int j = 0; j < mCount; j++) result += "0";
                    mCount = 0;
                } else {
                    result += "5";
                }
            }
        }
        if (mCount > 0) {
            for (int i = 0; i < mCount; i++) result += "1";
        }
        return result;
    }

    public static String getMinNum(String str) {
        String result = "";

        int length = str.length();
        int mCount = 0;
        for (int i = 0; i < length; i++) {
            String cur = str.charAt(i) + "";
            if (cur.equals("M")) mCount ++;
            else {
                if (mCount > 0) {   // K 앞에 1개 이상의 M이 있을 경우
                    result += "1";
                    for (int j = 0; j < mCount-1; j++) result += "0";
                    mCount = 0;
                }
                result += "5";  // K
            }
        }
        if (mCount > 0) {
            result += "1";
            for (int j = 0; j < mCount-1; j++) result += "0";
        }
        return result;
    }
}
