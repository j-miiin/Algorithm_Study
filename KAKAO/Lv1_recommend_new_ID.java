public class Lv1_recommend_new_ID {

    public static void main(String[] args) {
        System.out.println(solution(".!a."));
    }
    public static String solution(String new_id) {

        String step1_id = (new_id.toLowerCase() == "") ? new_id : new_id.toLowerCase();

        String step2_id = step1_id.replaceAll("[^a-z0-9-._]", "");

        String step3_id = replaceDotsToDot(step2_id);

        String step4_id = removeDotFromStartOrEnd(step3_id);

        String step5_id = "";
        if (step4_id == "") step5_id = "a";
        else step5_id = step4_id;

        String temp_id_for_step6 = "";
        if (step5_id.length() > 15) {
            temp_id_for_step6 = step5_id.substring(0, 15);
        } else temp_id_for_step6 = step5_id;

        String step6_id = removeDotFromStartOrEnd(temp_id_for_step6);

        String step7_id;
        if (step6_id.length() <= 2) {
            step7_id = lengthenShortID(step6_id);
        } else {
            step7_id = step6_id;
        }

        String answer = "";
        answer = step7_id;
        return answer;
    }

    public static String replaceDotsToDot(String str) {

        if (str == null) return null;

        String result = "";

        Character prev = ' ';
        for (int i = 0; i < str.length(); i++) {
            Character cur = str.charAt(i);

            if (cur == '.') {
                if (cur != prev) {
                    result += cur;
                    prev = cur;
                }
            } else {
                result += cur;
                prev = cur;
            }

        }

        return result;
    }

    public static String removeDotFromStartOrEnd(String str) {

        if (str == null) return null;

        String empty = "";
        if (str.equals(".")) return empty;

        if (str.charAt(0) == '.' && str.charAt(str.length()-1) == '.') {
            return str.substring(1, str.length()-1);
        } else if (str.charAt(0) == '.' && str.charAt(str.length()-1) != '.') {
            return str.substring(1);
        } else if (str.charAt(0) != '.' && str.charAt(str.length()-1) == '.') {
            return str.substring(0, str.length()-1);
        } else {
            return str;
        }
    }

    public static String lengthenShortID(String str) {
        Character targetChar = str.charAt(str.length()-1);

        String result = str;
        while(true) {
            if (result.length() == 3) break;

            result += targetChar;
        }

        return result;
    }
}
