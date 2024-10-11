
// 백준 - 폴리오미노 1343
// https://www.acmicpc.net/problem/1343

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class polyomino_1343 {

    public static final String A4 = "AAAA";
    public static final String B2 = "BB";

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        String board = br.readLine();
        StringBuilder sb = new StringBuilder();
        int count = 0;
        for (int i = 0; i < board.length(); i++) {
            if (board.charAt(i) == 'X') count++;
            else {
                if (coverBoard(count, sb)) {
                    count = 0;
                    sb.append(".");
                }
                else {
                    System.out.println(-1);
                    return;
                }
            }
        }
        if (count != 0) {
            if (!coverBoard(count, sb)) {
                System.out.println(-1);
                return;
            }
        }
        System.out.println(sb);
    }

    public static boolean coverBoard(int count, StringBuilder sb) {

        int a = 0, b = 0;
        int length = count;
        while (length - 4 >= 0) {
            length -= 4;
            a++;
        }
        while (length - 2 >= 0) {
            length -= 2;
            b++;
        }

        if (length != 0) return false;

        for (int i = 0; i < a; i++) sb.append(A4);
        for (int i = 0; i < b; i++) sb.append(B2);
        return true;
    }
}
