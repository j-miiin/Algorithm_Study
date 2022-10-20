
// 백준 - 번데기 15721
// https://www.acmicpc.net/problem/15721

package baekjoon.brute_force;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class pupa_15721 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int A = Integer.parseInt(br.readLine());
        int T = Integer.parseInt(br.readLine());
        int pupa = Integer.parseInt(br.readLine());

        int chant1 = 0, chant2 = 0;
        int turn = 1;
        int person = 0;
        while (true) {
            for (int i = 0; i < 2; i++) {
                chant1++;
                if (check(pupa, T, chant1, chant2)) {
                    System.out.println(person);
                    return;
                }
                person = (person + 1) % A;
                chant2++;
                if (check(pupa, T, chant1, chant2)) {
                    System.out.println(person);
                    return;
                }
                person = (person + 1) % A;
            }

            for (int i = 0; i < turn+1; i++) {
                chant1++;
                if (check(pupa, T, chant1, chant2)) {
                    System.out.println(person);
                    return;
                }
                person = (person + 1) % A;
            }

            for (int i = 0; i < turn+1; i++) {
                chant2++;
                if (check(pupa, T, chant1, chant2)) {
                    System.out.println(person);
                    return;
                }
                person = (person + 1) % A;
            }

            turn++;
        }
    }

    public static boolean check(int pupa, int T, int chant1, int chant2) {
        if (pupa == 0) {
            if (chant1 == T) return true;
        } else {
            if (chant2 == T) return true;
        }
        return false;
    }
}
