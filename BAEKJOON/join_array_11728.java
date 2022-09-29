
// 백준 - 배열 합치기 11728
// https://www.acmicpc.net/problem/11728

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class join_array_11728 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        int N = Integer.parseInt(st.nextToken());
        int M = Integer.parseInt(st.nextToken());

        int[] A = new int[N];
        int[] B = new int[M];
        st = new StringTokenizer(br.readLine());
        for (int i = 0; i < N; i++) A[i] = Integer.parseInt(st.nextToken());
        st = new StringTokenizer(br.readLine());
        for (int i = 0; i < M; i++) B[i] = Integer.parseInt(st.nextToken());

        StringBuilder sb = new StringBuilder();
        int aIdx = 0, bIdx = 0;
        while(aIdx < N && bIdx < M) {
            if (A[aIdx] <= B[bIdx]) sb.append(A[aIdx++]).append(" ");
            else sb.append(B[bIdx++]).append(" ");
        }

        if (aIdx < N) {
            while(aIdx < N) sb.append(A[aIdx++]).append(" ");
        }

        if (bIdx < M) {
            while(bIdx < M) sb.append(B[bIdx++]).append(" ");
        }

        System.out.println(sb);
    }
}
