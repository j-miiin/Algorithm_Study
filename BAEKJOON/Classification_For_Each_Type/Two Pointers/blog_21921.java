package baekjoon.two_pointers;

// 백준 - 블로그 21921
// https://www.acmicpc.net/problem/21921

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class blog_21921 {

    public static int N, X;
    public static int[] visitors;
    public static int max_visitor = 0;
    public static int periodCount = 0;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        N = Integer.parseInt(st.nextToken());
        X = Integer.parseInt(st.nextToken());
        visitors = new int[N+1];
        st = new StringTokenizer(br.readLine());
        for (int i = 1; i <= N; i++) visitors[i] = Integer.parseInt(st.nextToken());

        getMaxVisitors();
        System.out.println((max_visitor == 0) ? "SAD" : max_visitor + "\n" + periodCount);
    }

    public static void getMaxVisitors() {

        for (int i = 1; i <= N; i++) visitors[i] += visitors[i-1];
        visitors[0] = 0;

        for (int i = 0; i + X <= N; i++) {
            int cur = visitors[i+X] - visitors[i];
            if (max_visitor != 0 && max_visitor == cur) periodCount++;
            else if (max_visitor < cur) {
                max_visitor = cur;
                periodCount = 1;
            }
        }
    }
}
