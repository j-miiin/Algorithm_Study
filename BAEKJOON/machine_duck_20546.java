
// 백준 - 기적의 매매법 20546
// https://www.acmicpc.net/problem/20546

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class machine_duck_20546 {

    public static final int lastDay = 14;
    public static int defaultAsset;
    public static int[] stockPrice = new int[lastDay];
    public static int[] upDown = new int[lastDay];

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        defaultAsset = Integer.parseInt(br.readLine());

        int up = 1, down = -1;
        StringTokenizer st = new StringTokenizer(br.readLine());
        for (int i = 0; i < lastDay; i++) {
            stockPrice[i] = Integer.parseInt(st.nextToken());

            if (i > 0) {
                if (stockPrice[i] > stockPrice[i-1]) {
                    down = -1;
                    upDown[i] = up++;
                } else if (stockPrice[i] < stockPrice[i-1]) {
                    up = 1;
                    upDown[i] = down--;
                } else {
                    up = 1;
                    down = -1;
                }
            }
        }

        int hyuns = get_hyuns_profit();
        int mins = get_mins_profit();

        if (hyuns == mins) System.out.println("SAMESAME");
        else if (hyuns > mins) System.out.println("BNP");
        else System.out.println("TIMING");
    }

    public static int get_hyuns_profit() {
        int asset = defaultAsset;
        int stock = 0;

        for (int i = 0; i < lastDay; i++) {
            int cur = stockPrice[i];

            while (cur <= asset) {
                asset -= cur;
                stock++;
            }
        }

        return asset + stockPrice[lastDay-1] * stock;
    }

    public static int get_mins_profit() {
        int asset = defaultAsset;
        int stock = 0;

        for (int i = 0; i < lastDay; i++) {
            int cur = stockPrice[i];

            if (upDown[i] >= 3) {
                asset += cur * stock;
                stock = 0;
            } else if (upDown[i] <= -3) {
                while (cur <= asset) {
                    asset -= cur;
                    stock++;
                }
            }
        }

        return asset + stockPrice[lastDay-1] * stock;
    }
}
