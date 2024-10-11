
// 백준 - 숫자 카드 10815
// https://www.acmicpc.net/problem/10815

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.StringTokenizer;

public class number_card_10815 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());
        HashMap<Integer, Integer> myCards = new HashMap<>();
        StringTokenizer st = new StringTokenizer(br.readLine());
        for (int i = 0; i < N; i++) myCards.put(Integer.parseInt(st.nextToken()), 1);

        int M = Integer.parseInt(br.readLine());
        StringBuilder sb = new StringBuilder();
        st = new StringTokenizer(br.readLine());
        for (int i = 0; i < M; i++) {
            int cur = Integer.parseInt(st.nextToken());
            sb.append(myCards.getOrDefault(cur, 0)).append(" ");
        }
        System.out.println(sb);
    }
}
