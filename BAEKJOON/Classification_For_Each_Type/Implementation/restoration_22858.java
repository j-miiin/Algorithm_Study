package baekjoon.implementation;

// 백준 - 원상 복구 22858
// https://www.acmicpc.net/problem/22858

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class restoration_22858 {

    public static int N, K;
    public static int[] S, D;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        N = Integer.parseInt(st.nextToken());
        K = Integer.parseInt(st.nextToken());

        S = new int[N];
        D = new int[N];

        st = new StringTokenizer(br.readLine());
        for (int i = 0; i < N; i++) S[i] = Integer.parseInt(st.nextToken());

        st = new StringTokenizer(br.readLine());
        for (int i = 0; i < N; i++) D[i] = Integer.parseInt(st.nextToken());

        for (int i = 0; i < N; i++) {
            
        }
    }
}




