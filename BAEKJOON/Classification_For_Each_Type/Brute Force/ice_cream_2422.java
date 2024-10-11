
// 백준 - 한윤정이 이탈리아에 가서 아이스크림을 사먹는데 2422
// https://www.acmicpc.net/problem/2422

package baekjoon.brute_force;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class ice_cream_2422 {

    public static int N;
    public static boolean[] checked;
    public static int[] mix = new int[3];
    public static boolean[][] mixCombination;
    public static int result = 0;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        N = Integer.parseInt(st.nextToken());
        int M = Integer.parseInt(st.nextToken());
        checked = new boolean[N+1];
        mixCombination = new boolean[N+1][N+1];
        for (int i = 0; i < M; i++) {
            st = new StringTokenizer(br.readLine());
            int flavor1 = Integer.parseInt(st.nextToken());
            int flavor2 = Integer.parseInt(st.nextToken());
            mixCombination[flavor1][flavor2] = true;
        }

        mixFlavor(1, 0);
        System.out.println(result);
    }

    public static void mixFlavor(int start, int idx) {

        if (idx == 3) {
            if (check()) result++;
            return;
        }

        for (int i = start; i <= N; i++) {
            if (!checked[i]) {
                mix[idx] = i;
                checked[i] = true;
                mixFlavor(i+1, idx+1);
                checked[i] = false;
            }
        }
    }

    public static boolean check() {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                int flavor1 = mix[i];
                int flavor2 = mix[j];
                if (mixCombination[flavor1][flavor2]) return false;
            }
        }
        return true;
    }
}
