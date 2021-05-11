import React from 'react';
import {
  StyleSheet,
  Text,
  Image,
  View,
  FlatList,
} from 'react-native';

import DetailsShowButton from './../../components/DetailsShowButton';



export default function Details(props){

  const data = props.route.params.data

  return(
    <FlatList style={styles.container}
      ListHeaderComponent={ () =>{
        return(
          <View>
            <Image style={styles.itemimage} source={data.imageLink}/>

            <View style={{backgroundColor:'white',}}>
              <Text style={styles.title}>Informações Básicas</Text>            
            </View>

            <View style={{ flexDirection:'column', alignItems: 'center'}}>
                <DetailsShowButton name="Ordem Orbital" value={data.informacoesBasicas.ordemOrbital}/>
                <DetailsShowButton name="Distância Do Sol" value={data.informacoesBasicas.distanciaDoSol}/>
                <DetailsShowButton name="Massa" value={data.informacoesBasicas.massa}/>
                <DetailsShowButton name="Volume" value={data.informacoesBasicas.volume}/>
                <DetailsShowButton name="Densidade" value={data.informacoesBasicas.densidade}/>
                <DetailsShowButton name="Área da Superfície" value={data.informacoesBasicas.areaDaSuperficie}/>
                <DetailsShowButton name="Temperatura" value={data.informacoesBasicas.temperatura}/>
                <DetailsShowButton name="Período de Rotação" value={data.informacoesBasicas.periodoDeRotacao}/>
                <DetailsShowButton name="Período De Revolução" value={data.informacoesBasicas.periodoDeRevolucao}/>
                <DetailsShowButton name="Gravidade" value={data.informacoesBasicas.gravidade}/>
                <DetailsShowButton name="Velocidade De Escape" value={data.informacoesBasicas.velocidadeDeEscape}/>
                <DetailsShowButton name="Satélites" value={data.informacoesBasicas.satelites}/>
              </View>

              <View style={{backgroundColor:'white',}}>
                <Text style={styles.title}>Curiosidades</Text>            
              </View>

          </View>
        )
      }}
      data={data.curiosidades}
      keyExtractor={ item => item.id}
      showsVerticalScrollIndicator={false}
      renderItem = {({item,index}) =>(
        <View style={styles.curioHolder}>
          <Text style={styles.curioTitle}>{index+1}. {item.titulo}</Text>
          <Text style={styles.curioHistory}>{item.historia}</Text>
        </View>
      )}
    
    />
  )
}

const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor:'red',
      flexDirection: 'column',
      backgroundColor: 'black',
    },
    itemimage: {
      width:'100%',
      height: 200,
      flexGrow: 1,
      opacity: 0.9,
      borderRadius: 40,
      borderTopLeftRadius: 0,
      borderTopRightRadius: 0,
    },
    title: {
      color:'black', 
      fontSize:25,
      textAlign:'center',
    },
    curioHolder:{
      //marginHorizontal: 5,
      //marginVertical: 10,
    },
    curioTitle:{
      color: 'white',
      marginTop: 10,
      marginBottom: 5,
      textAlign: 'center',
      fontWeight: 'bold',
      fontSize: 25,
    },
    curioHistory:{
      color: 'white',
      textAlign: 'justify',
      marginHorizontal: 20,
    }

  });
