package baekjoon.brute_force;

// 백준 - 카드 놓기 5568
// https://www.acmicpc.net/problem/5568

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class put_card_5568 {

    public static int N, K;
    public static int[] card;
    public static boolean[] selected;

    public static ArrayList<String> num = new ArrayList<>();

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        N = Integer.parseInt(br.readLine());
        K = Integer.parseInt(br.readLine());
        card = new int[N];
        selected = new boolean[N];
        for (int i = 0; i < N; i++) card[i] = Integer.parseInt(br.readLine());

        selectNumber(0, new ArrayList<>());
        System.out.println(num.size());
    }

    public static void selectNumber(int count, ArrayList<Integer> numList) {

        if (count == K) {
            String curNum = "";
            for (int n : numList) curNum += n;
            if (!num.contains(curNum)) num.add(curNum);
            return;
        }

        for (int i = 0; i < N; i++) {
            if (!selected[i]) {
                selected[i] = true;
                ArrayList<Integer> newList = new ArrayList<>();
                for (int n : numList) newList.add(n);
                newList.add(card[i]);
                selectNumber(count + 1, newList);
                selected[i] = false;
            }
        }

    }
}
