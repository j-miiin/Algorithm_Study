
// 백준 - ATM 11399
// https://www.acmicpc.net/problem/11399

package baekjoon.greedy;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.StringTokenizer;

public class atm_11399 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());
        int[] time = new int[N];
        StringTokenizer st = new StringTokenizer(br.readLine());
        for (int i = 0; i < N; i++) time[i] = Integer.parseInt(st.nextToken());
        Arrays.sort(time);
        for (int i = 1; i < N; i++) time[i] += time[i-1];
        int result = 0;
        for (int i : time) result += i;
        System.out.println(result);
    }
}
