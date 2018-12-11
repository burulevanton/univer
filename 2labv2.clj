(defn calc_factors [fact y x] 
  (if (< y x)
    (if (= (rem x y) 0)
      (recur (conj fact y) 2 (/ x y))
      (recur fact (inc y) x))
    (conj fact y)))

(defn get_factors [x]
  (println (calc_factors [] 2 x)))

(get_factors 12)