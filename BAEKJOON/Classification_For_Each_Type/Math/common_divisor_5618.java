package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class common_divisor_5618 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int n = Integer.parseInt(br.readLine());

        int[] nums = new int[n];
        int max = 0;
        StringTokenizer st = new StringTokenizer(br.readLine());
        for (int i = 0; i < n; i++) {
            nums[i] = Integer.parseInt(st.nextToken());
            max = Math.max(max, nums[i]);
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 1; i <= max; i++) {
            boolean isDivisor = true;
            for (int j = 0; j < nums.length; j++) {
                if (nums[j] % i != 0) {
                    isDivisor = false;
                    break;
                }
            }
            if (isDivisor) sb.append(i).append("\n");
        }

        System.out.println(sb);
    }
}
