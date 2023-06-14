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

        for (int i = 0; i < str.length(); i++) quackList.add(str.charAt(i) + "");

        if (str.length() % 5 != 0 || str.charAt(0) != 'q') System.out.println(-1);
        else System.out.println(checkQuack());
    }

    public static int checkQuack() {

        String[] quack = {"q", "u", "a", "c", "k"};

        int checkIdx = 0;
        int duckCnt = 0;

        while (true) {

            for (int i = 0; i < quackList.size(); i++) {
                String cur = quackList.get(i);
                String target = quack[checkIdx];

                if (cur.equals(target)) {
                    quackList.remove(i);
                    i--;
                    checkIdx = (checkIdx + 1) % 5;
                }
            }

            if (checkIdx == 0) duckCnt++;
            else return -1;

            if (quackList.isEmpty()) return duckCnt;
        }
    }
}
