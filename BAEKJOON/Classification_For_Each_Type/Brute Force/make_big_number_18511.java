
// 백준 - 큰 수 구성하기 18511
// https://www.acmicpc.net/problem/18511

package baekjoon.brute_force;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.StringTokenizer;

public class make_big_number_18511 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        int N = Integer.parseInt(st.nextToken());
        int K = Integer.parseInt(st.nextToken());
        ArrayList<Integer> list = new ArrayList<>();
        st = new StringTokenizer(br.readLine());
        for (int i = 0; i < K; i++) list.add(Integer.parseInt(st.nextToken()));

        for (int i = N; i >= 0; i--) {
            String cur = i + "";
            boolean check = true;
            for (int j = 0; j < cur.length(); j++) {
                String c = cur.charAt(j) + "";
                if (!list.contains(Integer.parseInt(c))) {
                    check = false;
                    break;
                }
            }
            if (check) {
                System.out.println(cur);
                return;
            }
        }
    }

}
