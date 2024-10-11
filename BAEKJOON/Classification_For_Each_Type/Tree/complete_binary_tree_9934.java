
// 백준 - 완전 이진 트리 9934
// https://www.acmicpc.net/problem/9934

package baekjoon.tree;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class complete_binary_tree_9934 {

    public static int K;
    public static int[] nums;
    public static StringBuilder[] result;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        K = Integer.parseInt(br.readLine());
        int length = (int) (Math.pow(2, K) - 1);

        nums = new int[length];
        StringTokenizer st = new StringTokenizer(br.readLine());
        for (int i = 0; i < length; i++) nums[i] = Integer.parseInt(st.nextToken());

        result = new StringBuilder[length];
        for (int i = 0; i < length; i++) result[i] = new StringBuilder();

        makeTree(0, nums.length-1, 0);

        for (StringBuilder sb : result) System.out.println(sb);
    }

    public static void makeTree(int start, int end, int floor) {

        if (floor == K) return;

        int mid = (start + end) / 2;
        result[floor].append(nums[mid]).append(" ");

        makeTree(start, mid, floor + 1);
        makeTree(mid + 1, end, floor + 1);
    }
}
