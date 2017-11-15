# Array:数组
#包含统一的数据类型
numbers=[1,2,3]

#包含多种数类型
array=[1,"two",:three,{:name=>4}]

# Hash :key/value  dictionary
# 通用版本
jim={
    :name=>"jim",
    :age=>18
}
#1.9版本之后
jim={
    name: "jim",
    age: 18
}

#也可以写
jim={}
jim[:name]="jim"
jim[:age]=18


# symbol 与 string 是不一样的
a={:name=>"jim","name"=>"hi"}
puts a[:name]
puts a["name"]