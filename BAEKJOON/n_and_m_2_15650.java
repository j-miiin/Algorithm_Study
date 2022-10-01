
// 백준 - N과 M(2) 15650
// https://www.acmicpc.net/problem/15650

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class n_and_m_2_15650 {

    public static int N, M;
    public static int[] nums;
    public static boolean[] checked;
    public static StringBuilder sb = new StringBuilder();

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        N = Integer.parseInt(st.nextToken());
        M = Integer.parseInt(st.nextToken());
        nums = new int[N+1];
        checked = new boolean[N+1];
        for (int i = 1; i <= N; i++) nums[i] = i;
        dfs(1, 0, "");
        System.out.println(sb);
    }

    public static void dfs (int start, int count, String str) {

        if (count == M) {
            sb.append(str).append("\n");
            return;
        }

        for (int i = start; i <= N; i++) {
            if (!checked[i]) {
                checked[i] = true;
                dfs(i+1, count+1, str+i+" ");
                checked[i] = false;
            }
        }
    }
}
