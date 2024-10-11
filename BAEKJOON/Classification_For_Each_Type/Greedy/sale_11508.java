
// 백준 - 2+1 세일 11508
// https://www.acmicpc.net/problem/11508

package baekjoon.greedy;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.Collections;

public class sale_11508 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());
        Integer[] items = new Integer[N];
        for (int i = 0; i < N; i++) items[i] = Integer.parseInt(br.readLine());
        Arrays.sort(items, Collections.reverseOrder());
        int price = 0;
        for (int idx = 0; idx < N; ) {
            if (idx + 3 <= N) {
                price += items[idx] + items[idx+1];
                idx += 3;
            } else {
                price += items[idx];
                idx++;
            }
        }
        System.out.println(price);
    }
}
