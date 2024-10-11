
// 백준 - 222-풀링 17829
// https://www.acmicpc.net/problem/17829

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.StringTokenizer;

public class pooling_222_17829 {

    public static int N;
    public static int[][] matrix;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        N = Integer.parseInt(br.readLine());
        matrix = new int[N][N];
        for (int i = 0; i < N; i++) {
            StringTokenizer st = new StringTokenizer(br.readLine());
            for (int j = 0; j < N; j++) {
                matrix[i][j] = Integer.parseInt(st.nextToken());
            }
        }

        System.out.println(divide_conquer(0, 0, N));
    }

    public static int divide_conquer(int x, int y, int size) {

        if (size == 2) {
            return getSecondMax(matrix[x][y], matrix[x][y+1],
                    matrix[x+1][y], matrix[x+1][y+1]);
        } else {
            int s = size / 2;
            return getSecondMax(
                    divide_conquer(x, y, s),
                    divide_conquer(x, y+s, s),
                    divide_conquer(x+s, y, s),
                    divide_conquer(x+s, y+s, s)
            );
        }
    }

    public static int getSecondMax(int n1, int n2, int n3, int n4) {
        ArrayList<Integer> arr = new ArrayList<>(Arrays.asList(n1, n2, n3, n4));
        Collections.sort(arr, Collections.reverseOrder());
        return arr.get(1);
    }
}
