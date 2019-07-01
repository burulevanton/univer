(defn calc_factors [fact y x] 
  (if (< y x)
    (if (= (rem x y) 0)
      (recur (conj fact y) (inc y) x)
      (recur fact (inc y) x))
    (conj fact y)))

(defn get_factors [x]
  (println (calc_factors [] 1 x)))

(get_factors 15)