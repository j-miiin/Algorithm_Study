
// 백준 - 로프 2217
// https://www.acmicpc.net/problem/2217

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;

public class rope_2217 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());
        int[] ropes = new int[N];
        for (int i = 0; i < N; i++) ropes[i] = Integer.parseInt(br.readLine());
        Arrays.sort(ropes);

        long result = 0;
        int ropeNum = N;
        for (int i = 0; i < N; i++, ropeNum--) {
            result = Math.max(result, ropeNum * ropes[i]);
        }
        System.out.println(result);
    }
}
