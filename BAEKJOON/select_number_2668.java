
// 백준 - 숫자 고르기 2668
// https://www.acmicpc.net/problem/2668

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;

public class select_number_2668 {

    public static int N;
    public static int[][] table;
    public static boolean[] visited;

    public static int result = 0;
    public static ArrayList<Integer> resultList = new ArrayList<>();

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        N = Integer.parseInt(br.readLine());
        table = new int[2][N+1];
        visited = new boolean[N+1];
        for (int i = 1; i <= N; i++) {
            table[0][i] = i;
            table[1][i] = Integer.parseInt(br.readLine());
        }

        dfs(new ArrayList<>());
        StringBuilder sb = new StringBuilder();
        sb.append(result).append("\n");
        for (int i : resultList) sb.append(i).append("\n");
        System.out.println(sb);
    }

    public static void dfs(ArrayList<Integer> list) {

        HashSet<Integer> set = new HashSet<>();
        for (int i = 0; i < list.size(); i++) set.add(table[1][list.get(i)]);
        if (list.size() != set.size()) return;
        else {
            ArrayList<Integer> tmp = new ArrayList<>(set);
            Collections.sort(tmp);
            boolean isSame = true;
            for (int i = 0; i < list.size(); i++) {
                if (list.get(i) != tmp.get(i)) {
                    isSame = false;
                    break;
                }
            }
            if (isSame && result < list.size()) {
                resultList.clear();
                for (int i = 0; i < list.size(); i++) resultList.add(list.get(i));
            }
        }

        for (int i = 1; i <= N; i++) {
            if (!visited[i]) {
                visited[i] = true;
                ArrayList<Integer> newList = new ArrayList<>();
                for (int j : list) newList.add(j);
                newList.add(i);
                dfs(newList);
                visited[i] = false;
            }
        }
    }
}
