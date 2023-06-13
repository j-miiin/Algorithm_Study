package baekjoon.simulation;

// 백준 - 오리 12933
// https://www.acmicpc.net/problem/12933

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class duck_12933 {

    public static ArrayList<String> quackList = new ArrayList<>();

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        String str = br.readLine();

        for (int i = 0; i < str.length(); i++) {
            String cur = str.charAt(i) + "";
            if (!checkQuack(cur)) {
                System.out.println(-1);
                return;
            }
        }

        System.out.println(quackList.size());
    }

    public static boolean checkQuack(String str) {

        switch (str) {
            case "q":
                if (quackList.size() != 0) {
                    for (int i = 0; i < quackList.size(); i++) {
                        if (!quackList.get(i).equals("k")) i++;
                        else {
                            quackList.set(i, "q");
                            break;
                        }
                    }
                } else {
                    quackList.add("q");
                }
                break;
            case "u":
                if (quackList.size() != 0) {
                    for (int i = 0; i < quackList.size(); i++) {
                        if (!quackList.get(i).equals("k")) i++;
                        else {
                            quackList.set(i, "q");
                            break;
                        }
                    }
                } else {
                    quackList.add("q");
                }
                break;
            case "a":
                break;
            case "c":
                break;
            case "k":
                break;

        }
        return true;
    }
}
