(defn concattl[list1 list2]
  (loop [l1 list1
        l2 list2]
    (if( = (count l2) 0)
    l1
    (recur (conj l1 (first l2)) (rest l2))
    )
  )
)


(defn concatvl [& list]
  (let [new_list []]
    (loop [l list
          new_l new_list]
      (if( = (count l) 0)
      new_l
      (recur (rest l) (concattl new_l (first l)))
      )
    )
  )
)

(println(concatvl [1 2 3] [4 5 6] [7 8 9] [10 11 12] [13 14 15]))